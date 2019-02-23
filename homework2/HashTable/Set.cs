using System;
using SinglyLinkedList;

namespace HashTable
{
    class Set : ISet
    {
        private const int StartSize = 5;
        private List[] buckets = new List[StartSize];
        public int Size { get; private set; }        

        private float LoadFactor()
        {
            return (float)Size / buckets.Length;
        }

        private void Expand()
        {
            Array.Resize<List>(ref buckets, buckets.Length * 2);
            var buffer = new int[Size];
            int currentPosition = 0;

            foreach (var currentList in buckets)
            {
                while (!currentList.IsEmpty)
                {
                    buffer[currentPosition] = currentList[currentList.Length];
                    currentList.RemoveLast();
                    ++currentPosition;
                }
            }

            foreach (var currentValue in buffer)
            {
                Add(currentValue);
            }
        }

        public void Add(int value)
        {
            if (LoadFactor() > 1.0)
            {
                Expand();
            }

            if (!Exists(value))
            {
                buckets[Math.Abs(value) % buckets.Length].Insert(value);
                ++Size;
            }
        }

        public void Remove(int value)
        {
            if (buckets[Math.Abs(value) % buckets.Length].Exists(value, out int position))
            {
                buckets[Math.Abs(value) % buckets.Length].Remove(position);
                --Size;
            }
        }

        public bool Exists(int value)
        {
            return buckets[Math.Abs(value) % buckets.Length].Exists(value, out int position);
        }
    }
}
