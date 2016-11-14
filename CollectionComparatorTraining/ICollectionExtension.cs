using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionComparatorTraining
{
    static class ICollectionExtension
    {
        public static ICollection<T> Clone<T>(this IEnumerable<T> collectionToClone)// where T : ICloneable
        {
            Collection <T> clonned = new Collection<T>();
            foreach (T item in collectionToClone)
            {
                clonned.Add(item);
            }
            return clonned;


        }
        public static string ToStringCustom<T>(this IEnumerable<T> collection)
        {
            string s = "[ ";
            foreach(T item in collection)
            {
                s += item.ToString() + " ";
            }
            s += "]";
            return s;
        }
    }
}
