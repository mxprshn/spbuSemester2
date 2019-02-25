using System;

namespace StackCalculator
{
    class Calculator
    {
        private IStack stack;

        public Calculator(IStack stack)
        {
            this.stack = stack;
        }

        public int Evaluate(string expression)
        {
            string[] operands = expression.Split(' ');

            try
            {
                foreach (string operand in operands)
                {
                    if (int.TryParse(operand, out int number))
                    {
                        stack.Push(number);
                    }
                    else if (char.TryParse(operand, out char operation))
                    {
                        int operand1 = stack.Pop(out bool popResult1);
                        int operand2 = stack.Pop(out bool popResult2);

                        if (!popResult1 || !popResult2)
                        {
                            throw new FormatException();
                        }

                        switch (operation)
                        {
                            case '+':
                                {
                                    stack.Push(operand1 + operand2);
                                    break;
                                }
                            case '-':
                                {
                                    stack.Push(operand2 - operand1);
                                    break;
                                }
                            case '*':
                                {
                                    stack.Push(operand1 * operand2);
                                    break;
                                }
                            case '/':
                                {
                                    stack.Push(operand2 / operand1);
                                    break;
                                }
                            default:
                                {
                                    throw new FormatException();
                                }
                        }
                    }
                }

                int value = stack.Pop(out bool popResult);

                if (!popResult || !stack.IsEmpty)
                {
                    throw new FormatException();
                }

                return value;
            }

            catch (FormatException)
            {
                ConsoleColor previousColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ACHTUNG! УВАГА! Incorrect input.");
                Console.ForegroundColor = previousColor;
            }

            catch (DivideByZeroException)
            {
                ConsoleColor previousColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ACHTUNG! УВАГА! Dividing by zero.");
                Console.ForegroundColor = previousColor;
            }

            stack.Clear();
            return -1;
        }
    }
}
