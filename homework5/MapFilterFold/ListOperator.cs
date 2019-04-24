using System;
using System.Collections.Generic;

namespace MapFilterFold
{
    /// <summary>
    /// Class containing methods operating with a list of integer numbers.
    /// </summary>
    public static class ListOperator
    {
        /// <summary>
        /// Returns the new list containing elements of the source list modified by the given function.
        /// </summary>
        /// <param name="sourceList">List which elements are modified.</param>
        /// <param name="modifier">Function defining the modification applied to the elements.</param>
        /// <returns>New list which elements are modified elements of the source list.</returns>
        public static List<int> Map(List<int> sourceList, Func<int, int> modifier)
        {
            var result = new List<int>();

            foreach (var current in sourceList)
            {
                result.Add(modifier(current));
            }

            return result;
        }

        /// <summary>
        /// Returns the new list containing only those elements of the source list which satisfy the predicate.
        /// </summary>
        /// <param name="sourceList">List which elements are filtered.</param>
        /// <param name="filter">Predicate function defining the requirement for including an element to result list.</param>
        /// <returns>New list which contains the elements satisfying the predicate.</returns>
        public static List<int> Filter(List<int> sourceList, Predicate<int> filter)
        {
            var result = new List<int>();

            foreach (var current in sourceList)
            {
                if (filter(current))
                {
                    result.Add(current);
                }
            }

            return result;
        }

        /// <summary>
        /// Returns an integer value got after recalculation the parameter for each element of the list.
        /// </summary>
        /// <param name="sourceList">List for which elements the value is recalculated.</param>
        /// <param name="accumulated">Value to which the accumulator applied for the first time.</param>
        /// <param name="accumulator">Function defining recalculation of the accumulated value for an element of list.</param>
        /// <returns>Accumulated value.</returns>
        public static int Fold(List<int> sourceList, int accumulated, Func<int, int, int> accumulator)
        {
            foreach (var current in sourceList)
            {
                accumulated = accumulator(accumulated, current);
            }

            return accumulated;
        }
    }
}