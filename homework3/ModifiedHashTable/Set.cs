using System;
using SinglyLinkedList;

namespace ModifiedHashTable
{
    class Set : ISet
    {
        private const int StartSize = 5;
        private List[] buckets;
        public int Size { get; private set; }
        private IHashFunction hashFunction;
        
        public Set()
        {
            buckets = new List[StartSize];

            for (var i = 0; i < buckets.Length; ++i)
            {
                buckets[i] = new List();
            }
        }

        private int Hash(int value) => Math.Abs(value) % buckets.Length;

        private float LoadFactor() => (float)Size / buckets.Length;

        private void Expand()
        {
            var buffer = new string[Size];
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

        public bool Add(string value)
        {
            if (Exists(value))
            {
                return false;
            }

            if (LoadFactor() > 1.0)
            {
                Expand();
            }

            buckets[Hash(value)].InsertFirst(value);
            ++Size;
            return true;
        }

        public bool Remove(int value)
        {
            int targetPosition = buckets[Hash(value)].FindPosition(value);

            if (targetPosition < 0)
            {
                return false;
            }

            buckets[Hash(value)].Remove(targetPosition);
            --Size;
            return true;
        }

        public bool Exists(string value)
        {
            return buckets[Hash(value)].Exists(value);
        }
    }
}
