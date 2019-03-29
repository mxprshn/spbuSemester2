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
                test.InsertFirst(i);
            }

            test.PrintStatus();

            test.Remove(2);
            test.RemoveFirst();
            test.Remove(test.Length - 1);

            test.PrintStatus();

            test.InsertAfter(-1, 5);
            test.InsertAfter(-3, 0);

            test.PrintStatus();

            while (!test.IsEmpty)
            {
                test.RemoveFirst();
            }

            test.PrintStatus();

            Console.ReadKey();
        }
    }
}
