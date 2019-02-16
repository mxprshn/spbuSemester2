using System;

namespace SpiralTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = new int[,] { { 1, 2, 3, 4, 5 }, { 6, 7, 8, 9, 10 }, { 11, 12, 13, 14, 15 },
                                      { 16, 17, 18, 19, 20 }, { 21, 22, 23, 24, 25 } };

            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(0); ++j)
                {
                    Console.Write($"{matrix[i, j], -4}");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            var row = matrix.GetLength(0) / 2;
            var column = matrix.GetLength(0) / 2;

            for (var i = matrix.GetLength(0) / 2 + 1; i > 0; --i)
            {     
                while (column < matrix.GetLength(0) - i)
                {
                    Console.Write($"{matrix[row, column]} ");
                    ++column;
                }

                while (row < matrix.GetLength(0) - i)
                {
                    Console.Write($"{matrix[row, column]} ");
                    ++row;
                }

                while (column > i - 1)
                {
                    Console.Write($"{matrix[row, column]} ");
                    --column;
                }

                while (row >= i - 1)
                {
                    Console.Write($"{matrix[row, column]} ");
                    --row;
                }
            }

            Console.ReadKey();
        }
    }
}
