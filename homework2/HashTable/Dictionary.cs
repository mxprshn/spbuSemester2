using System;
using SinglyLinkedList;

namespace HashTable
{
    class Dictionary : IDictionary
    {
        private const int StartSize = 5;
        private List[] buckets = new List[StartSize];
        public int ElementsAmount { get; private set; } = 0;
        public float LoadFactor => (float)ElementsAmount / buckets.Length;

        private void Resize()
        {
            Array.Resize<List>(ref buckets, buckets.Length * 2);

        }

        public void Insert(string key, string value)
        {
            if (LoadFactor > 1)
            {
                Resize();
            }

            buckets[Math.Abs(key.GetHashCode()) % buckets.Length].Insert(key, value);
        }

        public void Remove(string key)
        {

        }

        public string GetValue(string key)
        {
            return buckets[Math.Abs(key.GetHashCode()) % buckets.Length][key];
        }

        public bool Exists(string key)
        {
            return GetValue(key) != null;
        }
    }
}
