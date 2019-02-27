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

            foreach (string operand in operands)
            {
                if (int.TryParse(operand, out int number))
                {
                    stack.Push(number);
                }
                else if (char.TryParse(operand, out char operation))
                {
                    var operand1 = stack.Pop(out bool popResult1);
                    var operand2 = stack.Pop(out bool popResult2);

                    if (!popResult1 || !popResult2)
                    {
                        stack.Clear();
                        throw new FormatException("Incorrect input");
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
                                if (operand1 == 0)
                                {
                                    stack.Clear();
                                    throw new DivideByZeroException("Division by zero");
                                }

                                stack.Push(operand2 / operand1);
                                break;
                            }
                        default:
                            {
                                stack.Clear();
                                throw new FormatException("Incorrect input");
                            }
                    }
                }
            }

            var value = stack.Pop(out bool popResult);

            if (!popResult || !stack.IsEmpty)
            {
                stack.Clear();
                throw new FormatException("Incorrect input");
            }

            return value;
        }
    }
}
