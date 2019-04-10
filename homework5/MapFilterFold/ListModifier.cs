using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapFilterFold
{
    public static class ListModifier
    {
        public static List<int> Map(List<int> sourceList, Func<int, int> modify)
        {
            var result = new List<int>();

            foreach (var current in sourceList)
            {
                result.Add(modify(current));
            }

            return result;
        }
    }
}
