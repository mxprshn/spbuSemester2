using System;
using System.IO;
using System.Text.RegularExpressions;

namespace ParsingTree
{
    public static class TreeCalculator
    {
        public static int CalculateTree(string fileName)
        {
            string textTree;

            using (var treeFileReader = new StreamReader(fileName))
            {
                textTree = treeFileReader.ReadLine();
            }

            ParseTree result = ParseToTree(textTree);
            result.Print();
            Console.WriteLine();
            return result.Value;
        }

        private static Node ParseNode(string[] tokens, ref int position)
        {
            Node newNode;

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
                    default:
                        {
                            newNode = new Division();
                            break;
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
            MatchCollection tokenMatches = Regex.Matches(textTree, @"-*\d+|[()*/+-]");
            string[] tokens = new string[tokenMatches.Count];

            for (var i = 0; i < tokens.Length; ++i)
            {
                tokens[i] = tokenMatches[i].Value;
            }

            int position = 0;
            return new ParseTree(ParseNode(tokens, ref position));
        }
    }
}