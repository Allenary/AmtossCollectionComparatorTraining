using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionComparatorTraining
{
    class Program
    {
        static void Main(string[] args)
        {
            Collection<String> c1 = new Collection<String> { "a", "b", "c", "d" };
            Collection<String> c2 = new Collection<String> { "a", "b", "b", "e" };

            string message="";
            bool isEquivalent = MyCollectionComparator<String>.Compare(c1, c2, out message);

            Console.WriteLine(isEquivalent+message);
            Console.ReadLine();
        }
    }
}
