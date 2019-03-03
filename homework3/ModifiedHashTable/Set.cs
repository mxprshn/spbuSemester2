using System;
using SinglyLinkedList;

namespace ModifiedHashTable
{
    public class Set : ISet
    {
        private const int StartSize = 5;
        private List[] buckets;
        public int Size { get; private set; }
        private IHashFunction hashFunction;
        
        public Set(IHashFunction hashFunction)
        {
            this.hashFunction = hashFunction;
            buckets = new List[StartSize];

            for (var i = 0; i < buckets.Length; ++i)
            {
                buckets[i] = new List();
            }
        }

        private float LoadFactor => (float)Size / buckets.Length;

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

            Size = 0;
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

            if (LoadFactor > 1.0)
            {
                Expand();
            }

            buckets[hashFunction.Hash(value) % (ulong)buckets.Length].InsertFirst(value);
            ++Size;
            return true;
        }

        public bool Remove(string value)
        {
            int targetPosition = buckets[hashFunction.Hash(value) % (ulong)buckets.Length].FindPosition(value);

            if (targetPosition < 0)
            {
                return false;
            }

            buckets[hashFunction.Hash(value) % (ulong)buckets.Length].Remove(targetPosition);
            --Size;
            return true;
        }

        public bool Exists(string value)
        {
            return buckets[hashFunction.Hash(value) % (ulong)buckets.Length].Exists(value);
        }
    }
}
