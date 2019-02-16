using System;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[] { -1, -11, -11, 0, 75, 11, 134, -11, 13, 87, -11, 100, 35, 0 };

            foreach (var i in array)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine();
            Sorting.Sort(ref array, 0, array.Length - 1);

            foreach (var i in array)
            {
                Console.Write($"{i} ");
            }

            Console.ReadKey();
        }
    }
}
