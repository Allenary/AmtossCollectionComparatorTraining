using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionComparatorTraining
{
    public static class MyCollectionComparator<T> where T : ICloneable
    {
        public static bool Compare(ICollection<T> collection1, ICollection<T> collection2, out string message)
        {
            message = "Collections are equivalent";
            if (Object.ReferenceEquals(collection1, collection2)) return true;
            if (collection1 == null || collection2 == null)
            {
                message = ComparizonMessage(collection1, collection2);
                return false;
            }
            var col1 = collection1.Clone();
            var col2 = collection2.Clone();

            foreach(T item in collection1)
            {
                if (collection2.Contains(item))
                {
                    col1.Remove(item);
                    col2.Remove(item);
                }
            }
            if (col1.Count == 0 && col2.Count == 0) return true;
            message = ComparizonMessage(col1, col2);
            return false;
        }

        private static string ComparizonMessage(ICollection<T> collection1, ICollection<T> collection2)
        {
            return "There are elements " + collection1.ToStringCustom() + " in Collection1  which are not included to Collection2\n" +
                  "There are elements" + collection2.ToStringCustom() + "in Collection2  which are not included to Collection1";
        }
    }
}
