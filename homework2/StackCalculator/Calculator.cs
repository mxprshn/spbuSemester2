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
                ConsoleColor color = Console.ForegroundColor;
                Console. 
                Console.WriteLine("Incorrect input");
                return -1;
            }

            catch (DivideByZeroException)
            {
                Console.WriteLine("Dividing by zero");
                return -1;
            }
        }
    }
}
