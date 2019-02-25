using System;

namespace StackCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            LStack stack = new LStack();
            Calculator calc = new Calculator(stack);

            Console.WriteLine($"{calc.Evaluate(Console.ReadLine())}");
            Console.ReadKey();
        }
    }
}
