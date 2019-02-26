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

        private int Hash(int value)
        {
            return Math.Abs(value);
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
                    buffer[currentPosition] = currentList[0];
                    currentList.RemoveFirst();
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

            buckets[Hash(value) % buckets.Length].InsertFirst(value);
            ++Size;
            return true;
        }

        public bool Remove(int value)
        {
            int targetPosition = buckets[Hash(value) % buckets.Length].FindPosition(value);

            if (targetPosition < 0)
            {
                return false;
            }

            buckets[Hash(value) % buckets.Length].Remove(targetPosition);
            --Size;
            return true;
        }

        public bool Exists(int value)
        {
            return buckets[Hash(value) % buckets.Length].Exists(value);
        }
    }
}
