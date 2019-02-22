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

            test.RemoveAfter(3);
            test.RemoveAfter(0);
            test.RemoveBefore(test.Length);

            test.PrintStatus();

            test.InsertAfter(-1, 5);
            test.InsertAfter(-2, test.Length);
            test.InsertBefore(-3, 0);

            test.PrintStatus();

            for (var i = 0; i < 10; ++i)
            {
                test.Remove();
            }

            test.PrintStatus();

            Console.ReadKey();
        }
    }
}
