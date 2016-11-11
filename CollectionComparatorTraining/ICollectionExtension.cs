using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionComparatorTraining
{
    static class ICollectionExtension
    {
        public static ICollection<T> Clone<T>(this ICollection<T> collectionToClone) where T : ICloneable
        {
            
                return collectionToClone.Select(item => (T)item.Clone()).ToList();
            
        }
        public static string ToStringCustom<T>(this ICollection<T> collection)
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
