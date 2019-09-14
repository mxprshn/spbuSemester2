using System;
using System.Collections.Generic;
using System.Collections;

namespace GenericList
{
    /// <summary>
    /// Class implementing generic linked list data structure. 
    /// </summary>
    /// <typeparam name="T">Type of the list elements.</typeparam>
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

        /// <summary>
        /// Gets amount of elements in the list.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Determines if the list is read-only.
        /// </summary>
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

        /// <summary>
        /// Appends a new element to the end of the list.
        /// </summary>
        /// <param name="newValue">A value to append.</param>
        public void Add(T newValue) => Insert(Count, newValue);

        /// <summary>
        /// Inserts a new element to the specified position of the list.
        /// </summary>
        /// <param name="position">A position which the new element will have.</param>
        /// <param name="newValue">A new value to insert.</param>
        /// <exception cref="ArgumentOutOfRangeException">Throws if position is invalid in the current list.</exception>
        public void Insert(int position, T newValue)
        {
            if (position < 0 || position > Count)
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

        /// <summary>
        /// Removes an element from the specified position of the list.
        /// </summary>
        /// <param name="position">A position of the element to remove.</param>
        /// <exception cref="ArgumentOutOfRangeException">Throws if position is invalid in the current list.</exception>
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

        /// <summary>
        /// Removes the first appearance of the value from the list.
        /// </summary>
        /// <param name="value">A value of the element to remove.</param>
        /// <returns>True if the element was found and removed, false otherwise.</returns>
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

        /// <summary>
        /// Gets or sets the value of the element at specified position.
        /// </summary>
        /// <param name="position">A position of the element to operate with.</param>
        /// <returns>Value of the element.</returns>
        public T this[int position]
        {
            get => FindByPosition(position).Value;

            set => FindByPosition(position).Value = value;
        }

        /// <summary>
        /// Determines if the element with specified value is in the list.
        /// </summary>
        /// <param name="value">A value of the element to check.</param>
        /// <returns>True if the list contains the element, false otherwise.</returns>
        public bool Contains(T value) => FindByValue(value).position != -1;

        /// <summary>
        /// Gets the index of the element with specified value.
        /// </summary>
        /// <param name="value">A value of the element to find.</param>
        /// <returns>Index of the element if it is found, -1 otherwise.</returns>
        public int IndexOf(T value) => FindByValue(value).position;

        /// <summary>
        /// Copies the elements of the list to an Array, starting at a particular Array index.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination
        ///     of the elements copied from list.
        /// </param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        /// <exception cref="ArgumentOutOfRangeException">ArrayIndex is less than 0.</exception>
        /// <exception cref="ArgumentNullException">Array is null.</exception>
        /// <exception cref="ArgumentException">The number of elements in the source
        ///     list is greater than the available space from arrayIndex to the end of the
        ///     destination array.
        /// </exception>
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

        /// <summary>
        /// Returns an enumerator that iterates through the list.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the list.</returns>
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

        /// <summary>
        /// Returns an enumerator that iterates through the list.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the list.</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// Removes all the elements from the list.
        /// </summary>
        public void Clear()
        {
            head = null;
            Count = 0;
        }
    }
}
