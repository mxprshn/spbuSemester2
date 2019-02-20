using System;

namespace FibonacciFactorial
{
    class Program
    {
        static int Factorial(int argument)
        {
            if (argument < 0)
            {
                return -1;
            }
            else if (argument <= 1)
            {
                return 1;
            }

            return argument * Factorial(argument - 1);
        }

        static int Fibonacci(int elementNumber)
        {
            if (elementNumber < 0)
            {
                return -1;
            }

            int previous = 0;
            int next = 1;

            for (var i = 1; i <= elementNumber; ++i)
            {
                var buffer = previous;
                previous = next;
                next = next + buffer;
            }

            return previous;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Fibonacci numbers: ");

            for (var i = -2; i <= 10; ++i)
            {
                Console.Write($"{Fibonacci(i) } ");
            }

            Console.WriteLine();
            Console.WriteLine("Factorial values: ");

            for (var i = -2; i <= 10; ++i)
            {
                Console.Write($"{Factorial(i) } ");
            }

            Console.ReadKey();
        }
    }
}
