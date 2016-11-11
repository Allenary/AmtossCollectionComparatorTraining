using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.ObjectModel;

namespace CollectionComparatorTraining.Test
{
    [TestClass]
    public class MyCollectionComparatorTest
    {
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
            var result = MyCollectionComparator2<String>.Compare(CollectionAbcd(), CollectionAbcd());

            Assert.AreEqual(true, result.AreEquivalent);
        }
        [TestMethod]
        public void MyCollectionComparator_ShouldReturnTrue_IfCollectionsHaveEqualElemaentsAndAreNotSorted()
        {
            string message;
            var result = MyCollectionComparator2<String>.Compare(CollectionAbcd(), CollectionBadc());

            Assert.AreEqual(true, result.AreEquivalent);
        }
        [TestMethod]
        public void MyCollectionComparator_ShouldReturnFalse_IfCollectionsHaveDifferentElements()
        {
            string message;
            var result = MyCollectionComparator2<String>.Compare(CollectionAbcd(), CollectionAbbc());

            Assert.AreEqual(false, result.AreEquivalent);
        }
        [TestMethod]
        public void MyCollectionComparator_ShouldReturnFalse_IfCollectionsHaveDifferentElementCount()
        {
            string message;
            var result = MyCollectionComparator2<String>.Compare(CollectionAbcd(), CollectionAbcde());

            Assert.AreEqual(false, result.AreEquivalent);
        }
        [TestMethod]
        public void MyCollectionComparator_ShouldReturnFalse_IfFirstCollectionIsEmpty()
        {
            string message;
            var result = MyCollectionComparator2<String>.Compare(EmptyCollection<String>(), CollectionAbcde());

            Assert.AreEqual(false, result.AreEquivalent);
        }
        [TestMethod]
        public void MyCollectionComparator_ShouldReturnFalse_IfSecondCollectionIsEmpty()
        {
            string message;
            var result = MyCollectionComparator2<String>.Compare(CollectionAbcde(), EmptyCollection<String>());

            Assert.AreEqual(false, result.AreEquivalent);
        }
        [TestMethod]
        public void MyCollectionComparator_ShouldReturnTrue_IfBothCollectionsAreEmpty()
        {
            string message;
            var result = MyCollectionComparator2<String>.Compare(EmptyCollection<String>(), EmptyCollection<String>());

            Assert.AreEqual(true, result.AreEquivalent);
        }
        [TestMethod]
        public void MyCollectionComparator_ShouldReturnFalse_IfFirstCollectionIsNull()
        {
            var result = MyCollectionComparator2<String>.Compare(null, CollectionAbcde());
            Assert.AreEqual(false, result.AreEquivalent);
        }
        [TestMethod]
        public void MyCollectionComparator_ShouldReturnFalse_IfSecondCollectionIsNull()
        {
            var result = MyCollectionComparator2<String>.Compare(CollectionAbcde(), null);
            Assert.AreEqual(false, result.AreEquivalent);
        }
        [TestMethod]
        public void MyCollectionComparator_ShouldReturnTrue_IfBothCollectionAreNull()
        {
            var result = MyCollectionComparator2<String>.Compare(null, null);
            Assert.AreEqual(true, result.AreEquivalent);
        }
    }
}
