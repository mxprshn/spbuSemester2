using System;

namespace QuickSort
{
    class Sorting
    {
        static private void Swap(ref int valueA, ref int valueB)
        {
            var buffer = valueB;
            valueB = valueA;
            valueA = buffer;
        }

        static private int ArrayPartition(ref int[] array, int leftBorder, int rightBorder)
        {
            var pivot = array[leftBorder];
            var position = leftBorder + 1;

            for (var i = leftBorder + 1; i <= rightBorder; ++i)
            {
                if (array[i] < pivot)
                {
                    Swap(ref array[i], ref array[position]);
                    ++position;
                }
            }

            Swap(ref array[leftBorder], ref array[position - 1]);
            return position - 1;
        }

        static public void Sort(ref int[] array, int leftBorder, int rightBorder)
        {
            if (leftBorder >= rightBorder)
            {
                return;
            }

            var divisor = ArrayPartition(ref array, leftBorder, rightBorder);
            Sort(ref array, leftBorder, divisor - 1);
            Sort(ref array, divisor + 1, rightBorder);
        }
    }
}
