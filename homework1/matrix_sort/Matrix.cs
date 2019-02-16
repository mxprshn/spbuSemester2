using System;

namespace MatrixSort
{
    class Matrix
    {
        private int[,] elements;
        private int height;
        private int width;

        public Matrix(int[,] source)
        {
            elements = source;
            height = source.GetUpperBound(0) + 1;
            width = source.GetUpperBound(1) + 1;
        }

        private void Swap(ref int valueA, ref int valueB)
        {
            int buffer = valueA;
            valueA = valueB;
            valueB = buffer;
        }

        private void SwapColumns(int columnA, int columnB)
        {
            for (var i = 0; i < height; ++i)
            {
                Swap(ref elements[i, columnA], ref elements[i, columnB]);
            }
        }

        public void SortColumns()
        {
            for (var i = 0; i < width; ++i)
            {
                int minimum = elements[0, i];
                int minimumPosition = i;

                for (var j = i + 1; j < width; ++j)
                {
                    if (elements[0, j] < minimum)
                    {
                        minimum = elements[0, j];
                        minimumPosition = j;
                    }
                }

                if (minimumPosition != i)
                {
                    SwapColumns(i, minimumPosition);
                }
            }
        }

        public void PrintElements()
        {
            for (var i = 0; i < height; ++i)
            {
                for (var j = 0; j < width; ++j)
                {
                    Console.Write($"{elements[i, j], -4} ");
                }

                Console.WriteLine();
            }
        }
    }
}
