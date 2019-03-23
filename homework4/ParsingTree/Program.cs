using System;

namespace ParsingTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{TreeCalculator.Calculate("77", true)}");
            Console.ReadKey();
        }
    }
}