using System;

namespace StackCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            IStack test1 = new LStack();
            IStack test2 = new AStack();

            for (var i = 0; i < 15; ++i)
            {
                test1.Push(i);
                test2.Push(test1.Peek(out _));
            }

            for (var i = 0; i < 20; ++i)
            {
                Console.WriteLine($"{test1.Pop(out bool result1)} : {result1}");
                Console.WriteLine($"{test2.Pop(out bool result2)} : {result2}");
            }

            Console.ReadKey();
        }
    }
}
