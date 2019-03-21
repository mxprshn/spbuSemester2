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

            using (var treeFileReader = new StreamReader("Input.txt"))
            {
                textTree = treeFileReader.ReadLine();
            }

            return ParseToTree(textTree).Value;
        }

        private static Node ParseNode(string[] tokens, ref int position)
        {

            return null;

        }

        private static ParseTree ParseToTree(string textTree)
        {
            MatchCollection tokenMatches = Regex.Matches(textTree, @"-*\d+|[()*/+-]");
            string[] tokens = new string[tokenMatches.Count];

            for (var i = 0; i < tokens.Length; ++i)
            {
                tokens[i] = tokenMatches[i].Value;
            }

            
        }
    }
}