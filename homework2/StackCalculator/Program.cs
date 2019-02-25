using System;

namespace StackCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            LStack LCalculationStack = new LStack();
            AStack ACalculationStack = new AStack();

            Calculator LCalculator = new Calculator(LCalculationStack);
            Calculator ACalculator = new Calculator(ACalculationStack);

            Console.WriteLine("0 -- Exit; 1 -- No, let's calculate something");
            string command = "";

            while (command != "0")
            {
                command = Console.ReadLine();

                if (command != "1")
                {
                    continue;
                }

                Console.Write("Enter an expression to calculate: ");
                var expression = Console.ReadLine();

                Console.WriteLine($"Calculator using stack using list says: {LCalculator.Evaluate(expression)}");
                Console.WriteLine($"Calculator using stack using array says: {LCalculator.Evaluate(expression)}");
            }
        }
    }
}
