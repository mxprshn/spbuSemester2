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

        private Node FindByPosition(int position)
        {
            if (position < 0 || position >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            var current = head;

            for (var i = 0; i < position; ++i)
            {
                current = current.Next;
            }

            return current;
        }
        
        private (Node node, int position) FindByValue(T value)
        {
            var current = head;

            for (var i = 0; i < Count; ++i)
            {
                if (current.Value.Equals(value))
                {
                    return (current, i);
                }

                current = current.Next;
            }

            return (null, -1);
        }

        public void Add(T newValue)
        {
            if (Count != 0)
            {
                var previousNode = FindByPosition(Count - 1);
                previousNode.Next = new Node(newValue);
            }
            else
            {
                Insert(0, newValue);
            }

            ++Count;
        }

        public void Insert(int position, T newValue)
        {
            if (position < 0 || position >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (position == 0)
            {
                head = new Node(newValue, head);
            }
            else
            {
                var previousNode = FindByPosition(position - 1);
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
                var previousNode = FindByPosition(position - 1);
                previousNode.Next = previousNode.Next.Next;
            }

            --Count;
        }

        public bool Remove(T value)
        {
            var second = head;
            Node first = null;

            while (second != null)
            {
                if (second.Value.Equals(value))
                {
                    if (first != null)
                    {
                        first.Next = second.Next;
                    }
                    else
                    {
                        head = second.Next;
                        second.Next = null;
                    }

                    --Count;
                    return true;
                }

                first = second;
                second = second.Next;
            }

            return false;
        }

        public T this[int position]
        {
            get => FindByPosition(position).Value;

            set => FindByPosition(position).Value = value;
        }

        public bool Contains(T value) => FindByValue(value).position != -1;

        public int IndexOf(T value) => FindByValue(value).position;

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
