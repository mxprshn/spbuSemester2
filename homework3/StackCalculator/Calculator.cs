using System;

namespace StackCalculator
{
    /// <summary>
    /// Class evaluating an integer expression in postfix notation.
    /// </summary>
    public class Calculator
    {
        private IStack stack;

        /// <summary>
        /// Creates a new Calculator.
        /// </summary>
        /// <param name="stack">Stack used in Calculator implementation.</param>
        public Calculator(IStack stack)
        {
            this.stack = stack;
        }

        /// <summary>
        /// Evaluates an integer expression in postfix notation.
        /// </summary>
        /// <param name="expression">Expression in postfix notation to evaluate.</param>
        /// <returns>Value of the expression.</returns>
        /// <exception cref="FormatException">Thrown in case of incorrect input. The calculating stack
        /// in this case may not remain empty.</exception>
        /// <exception cref="DivideByZeroException">Thrown if the expression includes dividing by zero. The calculating stack
        /// in this case may not remain empty.</exception>
        public int Evaluate(string expression)
        {
            string[] operandsAndOperations = expression.Split(' ');

            foreach (string operandOrOperation in operandsAndOperations)
            {
                if (int.TryParse(operandOrOperation, out int operand))
                {
                    stack.Push(operand);
                }
                else if (char.TryParse(operandOrOperation, out char operation))
                {
                    int operand1 = 0;
                    int operand2 = 0;

                    if (!stack.IsEmpty)
                    {
                        operand1 = stack.Pop();
                    }
                    else
                    {
                        throw new FormatException("Incorrect input");
                    }

                    if (!stack.IsEmpty)
                    {
                        operand2 = stack.Pop();
                    }
                    else
                    {
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
                                stack.Push(operand2 / operand1);
                                break;
                            }
                    }
                }
                else
                {
                    throw new FormatException("Incorrect input");
                }
            }

            int value = 0;

            if (!stack.IsEmpty)
            {
                value = stack.Pop();
            }
            else
            {
                throw new FormatException("Incorrect input");
            }

            if (!stack.IsEmpty)
            {
                throw new FormatException("Incorrect input");
            }

            return value;
        }
    }
}
