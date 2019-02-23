using System;
using SinglyLinkedList;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new List();
            test.Insert("1", "A");
            test.Insert("2", "B");
            test.InsertBefore("0", "Z", 0);
            test.InsertAfter("3", "C", 2);

            Console.WriteLine($"{test["2"]}");
            Console.WriteLine($"{test["1"]}");
            Console.WriteLine($"{test["3"]}");
            Console.WriteLine($"{-10 % 3}");


            Console.ReadKey();
        }
    }
}
