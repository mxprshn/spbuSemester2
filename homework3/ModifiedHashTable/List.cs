﻿using System;

namespace SinglyLinkedList
{
    /// <summary>
    /// Class implementing linked list data structure which contains string elements.
    /// </summary>
    public class List : IList
    {
        private class Node
        {
            public string Value { get; set; }
            public Node Next { get; set; }

            public Node(string newValue, Node newNext = null)
            {
                Value = newValue;
                Next = newNext;
            }
        }

        private Node head;

        /// <summary>
        /// Number of elements in the list.
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// Existence of elements in the list.
        /// </summary>
        public bool IsEmpty => head == null;

        private Node FindNode(int position)
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("The list was empty");
            }

            if (position < 0 || position >= Length)
            {
                throw new ArgumentOutOfRangeException("Incorrect index of position");
            }

            var temp = head;

            for (var i = 0; i < position; ++i)
            {
                temp = temp.Next;
            }

            return temp;
        }

        /// <summary>
        /// Inserts a new element in the beginning of the list.
        /// </summary>
        /// <param name="newValue">A string value to insert.</param>
        public void InsertFirst(string newValue)
        {
            head = new Node(newValue, head);
            ++Length;
        }

        /// <summary>
        /// Inserts a new element after another.
        /// </summary>
        /// <param name="newValue">A string value to insert.</param>
        /// <param name="previousPosition">Position of the previous element.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the parameter doesn't 
        /// match with any existing position.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the list is empty.</exception>
        public void InsertAfter(string newValue, int previousPosition)
        {
            var previousNode = FindNode(previousPosition);
            previousNode.Next = new Node(newValue, previousNode.Next);
            ++Length;         
        }

        /// <summary>
        /// Removes the first element of the list.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the list is empty.</exception>
        public void RemoveFirst()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("The list was empty");
            }

            head = head.Next;
            --Length;
        }

        /// <summary>
        /// Removes an element of the list from particular position.
        /// </summary>
        /// <param name="position">Position of the element to remove.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the parameter doesn't 
        /// match with any existing position.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the list is empty.</exception>
        public void Remove(int position)
        {
            if (position == 0)
            {
                RemoveFirst();
                return;
            }

            if (position == Length)
            {
                throw new ArgumentOutOfRangeException("Incorrect index of position");
            }

            var previousNode = FindNode(position - 1);
            previousNode.Next = previousNode.Next.Next;
            --Length;
        }

        /// <summary>
        /// Gets/sets an element on particular position.
        /// </summary>
        /// <param name="position">Position of the element to get/set.</param>
        /// <returns>A string element on </returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the parameter doesn't 
        /// match with any existing position.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the list is empty.</exception>
        public string this[int position]
        {
            get => FindNode(position).Value;

            set => FindNode(position).Value = value;
        }

        public bool Exists(string value)
        {
            var temp = head;

            for (var i = 0; i < Length; ++i)
            {
                if (temp.Value == value)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Finds the position of an element by its value.
        /// </summary>
        /// <param name="value">Value of the element to find.</param>
        /// <returns>Index of the element's position if it was found, -1 otherwise.</returns>
        public int FindPosition(string value)
        {
            var temp = head;

            for (var i = 0; i < Length; ++i)
            {
                if (temp.Value == value)
                {
                    return i;
                }

                temp = temp.Next;
            }

            return -1;
        }
    }
}
