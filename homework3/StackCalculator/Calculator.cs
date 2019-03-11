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
        /// <exception cref="FormatException">Thrown in case of incorrect input.</exception>
        /// <exception cref="DivideByZeroException">Thrown if the expression includes dividing by zero.</exception>
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
                    }
                }
                else
                {
                    stack.Clear();
                    throw new FormatException("Incorrect input");
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
