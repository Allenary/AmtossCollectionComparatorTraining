using System.Collections.Generic;
using System.Linq;

namespace CollectionComparatorTraining
{
    public enum ResultCode { Equal = 0, FirstHasUniqueItems = 1, SecondHasUniqueItems = 2, BothHasUniqueItems = 3 };

    public class ComparizonResult<T>
    {
        public bool AreEquivalent;
        public IEnumerable<T> UniqueItemsFromFirst;
        public IEnumerable<T> UniqueItemsFromSecond;


    }
    public static class MyCollectionComparator<T>
    {
        private const string equalString = "Collections are equivalent";
        private const string uniqueFirst = "There are unique items in Collection1: ";
        private const string uniqueSecond = "There are unique items in Collection2: ";

        public static bool Compare(IEnumerable<T> first, IEnumerable<T> second, out string message)
        {
            if (ReferenceEquals(first, second))
            {
                message = equalString;
                return true;
            }

            if ((first == null) || (second == null))
            {
                message = prepareMessage(first, second);
                return false;
            }

            //IEnumerable<T> UniqueItemsFromFirst = first.Except(second);
            //IEnumerable<T> UniqueItemsFromSecond = second.Except(first);

            var UniqueItemsFromFirst = first.Clone();
            var UniqueItemsFromSecond = second.Clone();

            foreach (T item in first)
            {
                if (second.Contains(item))
                {
                    UniqueItemsFromFirst.Remove(item);
                    UniqueItemsFromSecond.Remove(item);
                }
            }

            message = prepareMessage(UniqueItemsFromFirst, UniqueItemsFromSecond);

            return (UniqueItemsFromFirst.Count() == 0 && UniqueItemsFromSecond.Count() == 0);


        }
        private static string prepareMessage(IEnumerable<T> first, IEnumerable<T> second)
        {
            string message = "";
            if (first != null && first.Count() > 0) message += uniqueFirst + first.ToStringCustom() + ". ";
            if (second != null && second.Count() > 0) message += uniqueSecond + second.ToStringCustom();
            if (message == "") message = equalString;
            return message;
        }
    }
}
