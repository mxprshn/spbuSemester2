using System;
using SinglyLinkedList;

namespace HashTable
{
    class Set : ISet
    {
        private const int StartSize = 5;
        private List[] buckets;
        public int Size { get; private set; }
        
        public Set()
        {
            buckets = new List[StartSize];

            for (var i = 0; i < buckets.Length; ++i)
            {
                buckets[i] = new List();
            }
        }

        private float LoadFactor()
        {
            return (float)Size / buckets.Length;
        }

        private void Expand()
        {
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

            Array.Resize<List>(ref buckets, buckets.Length * 2);

            for (var i = buckets.Length / 2; i < buckets.Length; ++i)
            {
                buckets[i] = new List();
            }

            foreach (var currentValue in buffer)
            {
                Add(currentValue);
            }
        }

        public bool Add(int value)
        {
            if (Exists(value))
            {
                return false;
            }

            if (LoadFactor() > 1.0)
            {
                Expand();
            }

            buckets[Math.Abs(value) % buckets.Length].Insert(value);
            ++Size;
            return true;
        }

        public bool Remove(int value)
        {
            if (!buckets[Math.Abs(value) % buckets.Length].Exists(value, out int position))
            {
                return false;
            }

            buckets[Math.Abs(value) % buckets.Length].Remove(position);
            --Size;
            return true;
        }

        public bool Exists(int value)
        {
            return buckets[Math.Abs(value) % buckets.Length].Exists(value, out int position);
        }
    }
}
