using System;
using System.Text.RegularExpressions;

namespace ParsingTree
{
    public static class TreeCalculator
    {
        public static int Calculate(string textTree, bool printNeeded = false)
        {
            var result = ParseToTree(textTree);

            if (printNeeded)
            {
                result.Print();
                Console.WriteLine();
            }

            return result.Value;
        }

        private static Node ParseNode(string[] tokens, ref int position)
        {
            Node newNode;

            if (position >= tokens.Length)
            {
                throw new FormatException();
            }

            if (tokens[position] == "(")
            {
                ++position;

                switch (tokens[position])
                {
                    case "+":
                        {
                            newNode = new Addition();
                            break;
                        }
                    case "-":
                        {
                            newNode = new Subtraction();
                            break;
                        }
                    case "*":
                        {
                            newNode = new Multiplication();
                            break;
                        }
                    case "/":
                        {
                            newNode = new Division();
                            break;
                        }
                    default:
                        {
                            throw new FormatException();
                        }

                }

                ++position;
                newNode.Left = ParseNode(tokens, ref position);
                ++position;
                newNode.Right = ParseNode(tokens, ref position);
                ++position;
            }
            else
            {
                newNode = new Operand(int.Parse(tokens[position]));
            }

            return newNode;
        }

        private static ParseTree ParseToTree(string textTree)
        {
            var tokenMatches = Regex.Matches(textTree, @"-*\d+|[()*/+-]");
            var tokens = new string[tokenMatches.Count];

            for (var i = 0; i < tokens.Length; ++i)
            {
                tokens[i] = tokenMatches[i].Value;
            }

            int position = 0;
            var createdTree = new ParseTree(ParseNode(tokens, ref position));

            if ((position != tokens.Length - 1))
            {
                throw new FormatException();
            }

            return createdTree;
        }
    }
}