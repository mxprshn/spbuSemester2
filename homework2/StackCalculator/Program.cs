using System;

namespace StackCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var LCalculationStack = new ListStack();
            var ACalculationStack = new ArrayStack();

            var LCalculator = new Calculator(LCalculationStack);
            var ACalculator = new Calculator(ACalculationStack);

            Console.WriteLine("0 -- Exit; 1 -- No, let's calculate something");
            string command = "";

            while (command != "0")
            {
                command = Console.ReadLine();

                if (command != "1")
                {
                    continue;
                }

                try
                {
                    Console.Write("Enter an expression to calculate (divide operands with spaces): ");
                    var expression = Console.ReadLine();

                    Console.WriteLine($"Calculator using stack using list says: {LCalculator.Evaluate(expression)}");
                    Console.WriteLine($"Calculator using stack using array says: {ACalculator.Evaluate(expression)}");
                }

                catch(FormatException exception)
                {
                    Console.WriteLine(exception.Message);
                }

                catch(DivideByZeroException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
    }
}
