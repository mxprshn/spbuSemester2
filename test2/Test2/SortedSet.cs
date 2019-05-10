using System.Collections.Generic;
using System.Linq;

namespace Test2
{
    /// <summary>
    /// Class implementing sorted set of lists.
    /// </summary>
    /// <typeparam name="T">List type.</typeparam>
    /// <typeparam name="U">Type of list elements.</typeparam>
    public class SortedSet<T, U> where T : IList<U> 
    {
        private List<T> elements = new List<T>();
        private ListComparer<T, U> comparer = new ListComparer<T, U>();

        public bool Contains(T targetValue)
        {
            foreach (var i in elements)
            {
                if (targetValue.SequenceEqual(i))
                {
                    return true;
                }
            }

            return false;
        }

        public int Count { private set; get; } = 0;

        public bool Add(T newValue)
        {
            if (Contains(newValue))
            {
                return false;
            }

            var position = 0;

            while (position < elements.Count && comparer.Compare(elements[position], newValue) < 0)
            {
                position++;
            }

            elements.Insert(position, newValue);

            ++Count;
            return true;
        }

        public IList<U> this[int index]
        {
            get => elements[index];
        }
    }
}
