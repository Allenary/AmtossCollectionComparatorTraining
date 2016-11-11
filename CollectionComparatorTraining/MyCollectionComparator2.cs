using CollectionComparatorTraining;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionComparatorTraining
{
    public enum ResultCode { Equal = 0, FirstHasUniqueItems = 1, SecondHasUniqueItems = 2, BothHasUniqueItems = 3 };

    public class ComparizonResult<T>
    {
        public bool AreEquivalent;
       // public ResultCode Code;
        public IEnumerable<T> UniqueItemsFromFirst;
        public IEnumerable<T> UniqueItemsFromSecond;

        public string getMessage()
        {
            return "";
        }
    }
    public static class MyCollectionComparator2<T>
    {

        public static ComparizonResult<T> Compare(IEnumerable<T> first, IEnumerable<T> second)
        {
            ComparizonResult<T> result = new ComparizonResult<T>();
            if (ReferenceEquals(first, second))
            {
                result.AreEquivalent = true;
                return result;
            }
            if (first == null) {
                result.UniqueItemsFromSecond = second;
                result.AreEquivalent = false;
                return result;
            }
            

            if (second == null) {
                result.UniqueItemsFromFirst = first;
                result.AreEquivalent = false;
                return result;
            }
            
            result.UniqueItemsFromFirst = first.Except(second);
            result.UniqueItemsFromSecond = second.Except(first);
            result.AreEquivalent = (result.UniqueItemsFromFirst.Count() == 0 && result.UniqueItemsFromSecond.Count() == 0);

            return result;
        }
    }
}
