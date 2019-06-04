using System;
using System.Collections.Generic;
using System.Collections;

namespace GenericList
{
    public class List<T> : IList<T>
    {
        private class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }

            public Node(T newValue, Node newNext = null)
            {
                Value = newValue;
                Next = newNext;
            }
        }

        private Node head;

        public int Count { get; private set; }
        public bool IsReadOnly { get; } = false;

        private Node FindNode(int position)
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list was empty");
            }

            if (position < 0 || position >= Count)
            {
                throw new ArgumentOutOfRangeException("Incorrect index of position");
            }

            var current = head;

            for (var i = 0; i < position; ++i)
            {
                current = current.Next;
            }

            return current;
        }
        
        public void Add(T newValue)
        {
            head = new Node(newValue, head);
            ++Count;
        }

        public void Insert(int position, T newValue)
        {
            if (position > Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (position == 0)
            {
                Add(newValue);
            }
            else
            {
                var previousNode = FindNode(position - 1);
                previousNode.Next = new Node(newValue, previousNode.Next);
            }

            ++Count;
        }

        public void RemoveAt(int position)
        {
            if (position < 0 || position >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (position == 0)
            {
                head = head.Next;
            }
            else
            {
                var previousNode = FindNode(position - 1);
                previousNode.Next = previousNode.Next.Next;
            }

            --Count;
        }

        public bool Remove(T value)
        {

        }

        public T this[int position]
        {
            get => FindNode(position).Value;

            set => FindNode(position).Value = value;
        }

        public bool Contains(T value)
        {
            var current = head;

            for (var i = 0; i < Count; ++i)
            {
                if (current.Value.Equals(value))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public int IndexOf(T value)
        {
            var current = head;

            for (var i = 0; i < Count; ++i)
            {
                if (current.Value.Equals(value))
                {
                    return i;
                }

                current = current.Next;
            }

            return -1;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (array.Length - arrayIndex < Count)
            {
                throw new ArgumentException();
            }

            var position = arrayIndex;

            foreach (var current in this)
            {
                array[position] = current;
                ++position;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = head;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }

            yield break;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Clear()
        {
            head = null;
            Count = 0;
        }
    }
}
