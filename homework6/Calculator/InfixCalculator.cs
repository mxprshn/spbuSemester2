using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public static class InfixCalculator
    {
        private static readonly string[] highPrecedenceOperators = new string[] { "*", "/", "%" };
        private static readonly string[] lowPrecedenceOperators = new string[] { "+", "-" };

        private static bool IsHighPrecedence(string operation) => highPrecedenceOperators.Contains(operation);
        private static bool IsLowPrecedence(string operation) => lowPrecedenceOperators.Contains(operation);

        private static List<string> ParseToPostfix(string infixExpression)
        {
            var tokenMatches = Regex.Matches(infixExpression, @"(?<![\d)]\s*)-?\d+(,\d)?\d?|[()*/+%-]");
            var tokens = new List<string>();
            var output = new List<string>();
            var operationsAndBrackets = new Stack<string>();

            foreach (Match token in tokenMatches)
            {
                tokens.Add(token.Value);
            }

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

                    operationsAndBrackets.Pop();
                    // exception needed.
                }
            }

            foreach (var operation in operationsAndBrackets)
            {
                output.Add(operation);
            }

            return output;
        }

        public static double Calculate(string infixExpression)
        {
            var tokens = ParseToPostfix(infixExpression);
            var calculationStack = new Stack<double>();

            foreach (var token in tokens)
            {
                if (double.TryParse(token, out double operand))
                {
                    calculationStack.Push(operand);
                }
                else if (char.TryParse(token, out char operation))
                {
                    double operand1 = 0;
                    double operand2 = 0;

                    if (calculationStack.Count != 0)
                    {
                        operand1 = calculationStack.Pop();
                    }
                    else
                    {
                        throw new FormatException("Incorrect input");
                    }

                    if (calculationStack.Count != 0)
                    {
                        operand2 = calculationStack.Pop();
                    }
                    else
                    {
                        throw new FormatException("Incorrect input");
                    }

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
                        case '*':
                            {
                                calculationStack.Push(operand1 * operand2);
                                break;
                            }
                        case '/':
                            {
                                calculationStack.Push(operand2 / operand1);
                                break;
                            }
                    }
                }
                else
                {
                    throw new FormatException("Incorrect input");
                }
            }

            double value = 0;

            if (calculationStack.Count != 0)
            {
                value = calculationStack.Pop();
            }
            else
            {
                throw new FormatException("Incorrect input");
            }

            if (calculationStack.Count != 0)
            {
                throw new FormatException("Incorrect input");
            }

            return value;
        }
    }
}
