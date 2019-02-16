using System;

namespace MatrixSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var source = new int[,] { { 0, -1, 2, -55 }, { 0, 77, 0, 2 }, { -99, 33, 22, 11 }, { 3, 5, 0, 0 }, { 100, 100, 100, 1 } };
            Matrix testMatrix = new Matrix(source);
            testMatrix.PrintElements();
            testMatrix.SortColoumns();
            Console.WriteLine();
            testMatrix.PrintElements();
            Console.ReadKey();
        }
    }
}
