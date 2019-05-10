using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2
{
    public class ListComparer<T, U> : IComparer<T> where T : IList<U>
    {
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