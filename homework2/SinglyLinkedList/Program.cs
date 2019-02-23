using System;

namespace SinglyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new List();

            for (var i = 0; i < 10; ++i)
            {
                test.Insert(i);
            }

            test.PrintStatus();

            test.Remove(2);
            test.RemoveLast();
            test.Remove(test.Length - 1);

            test.PrintStatus();

            test.InsertBefore(-1, 5);
            test.InsertBefore(-2, test.Length);
            test.InsertBefore(-3, 0);

            test.PrintStatus();

            for (var i = 0; i < 10; ++i)
            {
                test.RemoveLast();
            }

            test.PrintStatus();

            Console.ReadKey();
        }
    }
}
