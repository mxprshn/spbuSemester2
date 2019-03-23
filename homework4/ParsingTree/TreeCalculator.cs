using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace ParsingTree
{
    /// <summary>
    /// Class for calculating the expression value by its parsing tree. 
    /// </summary>
    public static class TreeCalculator
    {
        /// <summary>
        /// Calculates the value of expression by its parsing tree given as a string.
        /// </summary>
        /// <param name="textTree">Expression parsing tree as a string of the following 
        /// format: (<operator> <operand/subtree> <operand/subtree>).</param>
        /// <param name="printNeeded">If 'true' the tree is printed to console, 
        /// by default is 'false'.</param>
        /// <returns>Value of the expression.</returns>
        /// <exception cref="FormatException">Thrown in case of incorrect input.</exception>
        /// <exception cref="DivideByZeroException">Thrown if the expression includes
        /// dividing by zero.</exception>
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

        /// <summary>
        /// Generates a new node for the parse tree.
        /// </summary>
        /// <param name="tokens">Queue of operands, operations and parentheses.</param>
        /// <returns>Generated node.</returns>
        private static Node ParseNode(Queue<string> tokens)
        {
            Node newNode;

            if (tokens.Peek() == "(")
            {
                tokens.Dequeue();

                switch (tokens.Peek())
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

                tokens.Dequeue();
                newNode.Left = ParseNode(tokens);
                newNode.Right = ParseNode(tokens);
                tokens.Dequeue();
            }
            else
            {
                newNode = new Operand(int.Parse(tokens.Peek()));
                tokens.Dequeue();
            }

            return newNode;
        }

        /// <summary>
        /// Generates the parse tree of arithmetical expression by its text representation.
        /// </summary>
        /// <param name="textTree">Text representation of the tree.</param>
        /// <returns>Generated tree.</returns>
        /// <exception cref="FormatException">Thrown in case of incorrect text tree string.</exception>
        private static ParseTree ParseToTree(string textTree)
        {
            var tokenMatches = Regex.Matches(textTree, @"-*\d+|[()*/+-]");
            var tokens = new Queue<string>();
            ParseTree generatedTree;

            foreach (Match token in tokenMatches)
            {
                tokens.Enqueue(token.Value);
            }

            try
            {
                generatedTree = new ParseTree(ParseNode(tokens));
            }
            catch (InvalidOperationException)
            {
                throw new FormatException();
            }

            if (tokens.Count != 0)
            {
                throw new FormatException();
            }

            return generatedTree;
        }
    }
}