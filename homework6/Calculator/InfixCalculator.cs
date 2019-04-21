using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
    /// <summary>
    /// Class calculating an expression in infix notation.
    /// </summary>
    public static class InfixCalculator
    {
        private static readonly string[] HighPrecedenceOperators = new string[] { "×", "÷", "%" };
        private static readonly string[] LowPrecedenceOperators = new string[] { "+", "-" };

        private static bool IsHighPrecedence(string operation) => HighPrecedenceOperators.Contains(operation);
        private static bool IsLowPrecedence(string operation) => LowPrecedenceOperators.Contains(operation);

        private static List<string> ParseToPostfix(string infixExpression)
        {
            var tokenMatches = Regex.Matches(infixExpression, @"(?<![\d)]\s*)-?\d+(,\d)?\d*|[()×÷+%-]");
            var tokens = new List<string>();
            var output = new List<string>();
            var operationsAndBrackets = new Stack<string>();

            foreach (Match token in tokenMatches)
            {
                tokens.Add(token.Value);
            }

            try
            {
                foreach (var token in tokens)
                {
                    if (double.TryParse(token, out _))
                    {
                        output.Add(token);
                    }
                    else if (token == "(")
                    {
                        operationsAndBrackets.Push(token);
                    }
                    else if (IsHighPrecedence(token))
                    {
                        while (operationsAndBrackets.Count != 0 && IsHighPrecedence(operationsAndBrackets.Peek()))
                        {
                            output.Add(operationsAndBrackets.Pop());
                        }

                        operationsAndBrackets.Push(token);
                    }
                    else if (IsLowPrecedence(token))
                    {
                        while (operationsAndBrackets.Count != 0 && (IsHighPrecedence(operationsAndBrackets.Peek())
                                || IsLowPrecedence(operationsAndBrackets.Peek())))
                        {
                            output.Add(operationsAndBrackets.Pop());
                        }

                        operationsAndBrackets.Push(token);
                    }
                    else if (token == ")")
                    {
                        while (operationsAndBrackets.Peek() != "(")
                        {
                            output.Add(operationsAndBrackets.Pop());
                        }

                        _ = operationsAndBrackets.Pop();
                    }
                }

                foreach (var operation in operationsAndBrackets)
                {
                    output.Add(operation);
                }

                return output;
            }

            catch (InvalidOperationException)
            {
                throw new FormatException("Incorrect infix notation expression.");
            }
        }

        /// <summary>
        /// Calculates an infix notation expression.
        /// </summary>
        /// <param name="infixExpression">Infix expression to calculate.</param>
        /// <returns>Value of the expression.</returns>
        ///<exception cref="FormatException">Thrown in case of incorrect input expression.</exception>
        public static double Calculate(string infixExpression)
        {
            var tokens = ParseToPostfix(infixExpression);
            var calculationStack = new Stack<double>();

            try
            {
                foreach (var token in tokens)
                {
                    if (double.TryParse(token, out double operand))
                    {
                        calculationStack.Push(operand);
                    }
                    else if (char.TryParse(token, out char operation))
                    {
                        var operand1 = calculationStack.Pop();
                        var operand2 = calculationStack.Pop();

                        switch (operation)
                        {
                            case '+':
                                {
                                    calculationStack.Push(operand1 + operand2);
                                    break;
                                }
                            case '-':
                                {
                                    calculationStack.Push(operand2 - operand1);
                                    break;
                                }
                            case '×':
                                {
                                    calculationStack.Push(operand1 * operand2);
                                    break;
                                }
                            case '÷':
                                {
                                    if (operand1 == 0)
                                    {
                                        throw new DivideByZeroException();
                                    }

                                    calculationStack.Push(operand2 / operand1);
                                    break;
                                }
                            case '%':
                                {
                                    calculationStack.Push(operand2 * operand1 * 0.01);
                                    break;
                                }
                        }
                    }
                    else
                    {
                        throw new FormatException("Incorrect infix notation expression.");
                    }
                }

                var value = calculationStack.Pop();

                if (calculationStack.Count != 0)
                {
                    throw new FormatException("Incorrect infix notation expression.");
                }

                return value;
            }

            catch (InvalidOperationException)
            {
                throw new FormatException("Incorrect infix notation expression.");
            }            
        }
    }
}