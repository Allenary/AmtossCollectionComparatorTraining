using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CollectionComparatorTraining;

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
            string message;
            bool result = MyCollectionComparator<String>.Compare(CollectionAbcd(), CollectionAbcd(), out message);

            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void MyCollectionComparator_ShouldReturnTrue_IfCollectionsHaveEqualElemaentsAndAreNotSorted()
        {
            string message;
            bool result = MyCollectionComparator<String>.Compare(CollectionAbcd(), CollectionBadc(), out message);

            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void MyCollectionComparator_ShouldReturnFalse_IfCollectionsHaveDifferentElements()
        {
            string message;
            bool result = MyCollectionComparator<String>.Compare(CollectionAbcd(), CollectionAbbc(), out message);

            Assert.AreEqual(false, result);
        }
        [TestMethod]
        public void MyCollectionComparator_ShouldReturnFalse_IfCollectionsHaveDifferentElementCount()
        {
            string message;
            bool result = MyCollectionComparator<String>.Compare(CollectionAbcd(), CollectionAbcde(), out message);

            Assert.AreEqual(false, result);
        }
        [TestMethod]
        public void MyCollectionComparator_ShouldReturnFalse_IfFirstCollectionIsEmpty()
        {
            string message;
            bool result = MyCollectionComparator<String>.Compare(EmptyCollection<String>(), CollectionAbcde(), out message);

            Assert.AreEqual(false, result);
        }
        [TestMethod]
        public void MyCollectionComparator_ShouldReturnFalse_IfSecondCollectionIsEmpty()
        {
            string message;
            bool result = MyCollectionComparator<String>.Compare(CollectionAbcde(), EmptyCollection<String>(), out message);

            Assert.AreEqual(false, result);
        }
        [TestMethod]
        public void MyCollectionComparator_ShouldReturnTrue_IfBothCollectionsAreEmpty()
        {
            string message;
            bool result = MyCollectionComparator<String>.Compare(EmptyCollection<String>(), EmptyCollection<String>(), out message);

            Assert.AreEqual(true, result);
        }
    }
}
