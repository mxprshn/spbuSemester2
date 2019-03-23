using System;
using System.IO;

namespace ParsingTree
{
    class Program
    {
        static void Main(string[] args)
        {
            string textTree;

            using (var treeFileReader = new StreamReader("..\\..\\Input.txt"))
            {
                textTree = treeFileReader.ReadLine();
            }

            Console.Write("Parsing tree from the file: ");
            var value = TreeCalculator.Calculate(textTree, true);
            Console.WriteLine($"Value of the tree: {value}");
        }
    }
}