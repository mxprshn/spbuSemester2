using System;
using SinglyLinkedList;

namespace ModifiedHashTable
{
    /// <summary>
    /// Class implementing set data structure, which contains unique string elements.
    /// </summary>
    public class Set : ISet
    {
        private const int StartSize = 5;
        private List[] buckets;

        /// <summary>
        /// Number of elements in the set.
        /// </summary>
        public int Size { get; private set; }

        private IHashFunction hashFunction;
        
        /// <summary>
        /// Creates a new Set object.
        /// </summary>
        /// <param name="hashFunction">Hash function which will be used in set implementation.</param>
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
            Array.Resize(ref buckets, buckets.Length * 2);

            for (var i = buckets.Length / 2; i < buckets.Length; ++i)
            {
                buckets[i] = new List();
            }

            foreach (var currentValue in buffer)
            {
                Add(currentValue);
            }
        }

        /// <summary>
        /// Adds a new string value to the set if it doesn't already exist.
        /// </summary>
        /// <param name="value">A string value to add.</param>
        /// <returns>True if the value didn't exist and was added, False if the value already exists.</returns>
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

        /// <summary>
        /// Removes a string value from the set if it exists there.
        /// </summary>
        /// <param name="value">A string value to remove.</param>
        /// <returns>True if the value existed and was removed, False if the value doesn't exist.</returns>
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

        /// <summary>
        /// Checks a string value for existence in the set.
        /// </summary>
        /// <param name="value">A string value to check for existence.</param>
        /// <returns>True if the value exists, otherwise False.</returns>
        public bool Exists(string value) => buckets[hashFunction.Hash(value) % (ulong)buckets.Length].Exists(value);
    }
}
