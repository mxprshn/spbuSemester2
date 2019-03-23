using System;

namespace ParsingTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{TreeCalculator.Calculate("(/ 1 0)", true)}");
            Console.ReadKey();
        }
    }
}