using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace CollectionComparatorTraining.Test
{
    [TestClass]
    public class MyCollectionComparatorTest
    {
        private const string equalString = "Collections are equivalent";
        private Collection<T> EmptyCollection<T>()
        {
            return new Collection<T>();
        }
        private Collection<String> CollectionAbcd()
        {
            return new Collection<String> { "a", "b", "c", "d"};
        }
        private Collection<String> CollectionBadc()
        {
            return new Collection<String> { "b", "a", "d", "c" };
        }

        private Collection<String> CollectionAbcde()
        {
            return new Collection<String> { "a", "b", "c", "d", "e" };
        }

        private Collection<String> CollectionAbbc()
        {
            return new Collection<String> { "a", "b", "b", "c"};
        }

        [TestMethod]
        public void MyCollectionComparator_ShouldReturnTrue_IfCollectionsHaveEqualElemaentsAndSameSortOrder()
        {
            string message;
            var result = MyCollectionComparator<String>.Compare(CollectionAbcd(), CollectionAbcd(), out message);

            Assert.AreEqual(true, result);
            Assert.AreEqual(equalString, message);
        }
        [TestMethod]
        public void MyCollectionComparator_ShouldReturnTrue_IfCollectionsHaveEqualElementsAndAreNotSorted()
        {
            string message;
            bool result = MyCollectionComparator<String>.Compare(CollectionAbcd(), CollectionBadc(), out message);

            Assert.AreEqual(true, result);
            Assert.AreEqual(equalString, message);
        }
        [TestMethod]
        public void MyCollectionComparator_ShouldReturnFalse_IfCollectionsHaveDifferentElements()
        {
            string message;
            var result = MyCollectionComparator<String>.Compare(CollectionAbcd(), CollectionAbbc(), out message);

            Assert.AreEqual(false, result);
            Assert.AreEqual("There are unique items in Collection1: [ d ]. There are unique items in Collection2: [ b ]", message);
            
        }
        [TestMethod]
        public void MyCollectionComparator_ShouldReturnFalse_IfCollectionsHaveDifferentElementCount()
        {
            string message;
            var result = MyCollectionComparator<String>.Compare(CollectionAbcd(), CollectionAbcde(), out message);

            Assert.AreEqual(false, result);
            Assert.AreEqual("There are unique items in Collection2: [ e ]", message);
        }
        [TestMethod]
        public void MyCollectionComparator_ShouldReturnFalse_IfFirstCollectionIsEmpty()
        {
            string message;
            var result = MyCollectionComparator<String>.Compare(EmptyCollection<String>(), CollectionAbcde(), out message);

            Assert.AreEqual(false, result);
            Assert.AreEqual("There are unique items in Collection2: [ a b c d e ]", message);
        }
        [TestMethod]
        public void MyCollectionComparator_ShouldReturnFalse_IfSecondCollectionIsEmpty()
        {
            string message;
            var result = MyCollectionComparator<String>.Compare(CollectionAbcde(), EmptyCollection<String>(), out message);

            Assert.AreEqual(false, result);
            Assert.AreEqual("There are unique items in Collection1: [ a b c d e ]. ", message);
        }
        [TestMethod]
        public void MyCollectionComparator_ShouldReturnTrue_IfBothCollectionsAreEmpty()
        {
            string message;
            var result = MyCollectionComparator<String>.Compare(EmptyCollection<String>(), EmptyCollection<String>(), out message);

            Assert.AreEqual(true, result);
            Assert.AreEqual(equalString, message);
        }
        [TestMethod]
        public void MyCollectionComparator_ShouldReturnFalse_IfFirstCollectionIsNull()
        {
            string message;
            var result = MyCollectionComparator<String>.Compare(null, CollectionAbcde(), out message);

            Assert.AreEqual(false, result);
            Assert.AreEqual("There are unique items in Collection2: [ a b c d e ]", message);
        }
        [TestMethod]
        public void MyCollectionComparator_ShouldReturnFalse_IfSecondCollectionIsNull()
        {
            string message;
            var result = MyCollectionComparator<String>.Compare(CollectionAbcde(), null, out message);

            Assert.AreEqual(false, result);
            Assert.AreEqual("There are unique items in Collection1: [ a b c d e ]. ", message);
        }
        [TestMethod]
        public void MyCollectionComparator_ShouldReturnTrue_IfBothCollectionAreNull()
        {
            string message;
            var result = MyCollectionComparator<String>.Compare(null, null, out message);

            Assert.AreEqual(true, result);
            Assert.AreEqual(equalString, message);
        }
    }
}
