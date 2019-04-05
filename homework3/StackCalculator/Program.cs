using System;

namespace StackCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var listCalculationStack = new ListStack();
            var arrayCalculationStack = new ArrayStack();

            var listStackCalculator = new Calculator(listCalculationStack);
            var arrayStackCalculator = new Calculator(arrayCalculationStack);

            Console.WriteLine("0 -- Exit; 1 -- No, let's calculate something");
            var command = "";

            while (command != "0")
            {
                command = Console.ReadLine();

                if (command != "1")
                {
                    continue;
                }

                try
                {
                    Console.Write("Enter a posfix expression (integer numbers, '+', '-', '*', '/', divided by spaces): ");
                    var expression = Console.ReadLine();

                    Console.WriteLine($"Calculator using stack using list says: {listStackCalculator.Evaluate(expression)}");
                    Console.WriteLine($"Calculator using stack using array says: {arrayStackCalculator.Evaluate(expression)}");
                }

                catch (FormatException exception)
                {
                    Console.WriteLine(exception.Message);
                }

                catch (DivideByZeroException)
                {
                    Console.WriteLine("Dividing by zero.");
                }

                finally
                {
                    listCalculationStack.Clear();
                    arrayCalculationStack.Clear();
                }
            }
        }
    }
}
