using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2
{
    /// <summary>
    /// Class comparing two lists by its elements amount.
    /// </summary>
    /// <typeparam name="T">List of U-typed elements.</typeparam>
    /// <typeparam name="U">Type of list elements.</typeparam>
    public class ListComparer<T, U> : IComparer<T> where T : IList<U>
    {
        /// <summary>
        /// Compares two lists.
        /// </summary>
        /// <param name="firstList">First list to compare.</param>
        /// <param name="secondList">Second list to compare.</param>
        /// <returns>0 -- are equal, -1 -- first less, 1 -- second less.</returns>
        public int Compare(T firstList, T secondList)
        {
            if (firstList.Count == secondList.Count)
            {
                return 0;
            }

            if (firstList.Count < secondList.Count)
            {
                return -1;
            }

            return 1;
        }
    }
}