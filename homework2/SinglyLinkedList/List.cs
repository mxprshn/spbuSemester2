﻿using System;

namespace SinglyLinkedList
{
    class List : IList
    {
        private class Node
        {
            public int Value { get; set; }
            public Node Next { get; set; }

            public Node(int newValue, Node newNext)
            {
                Value = newValue;
                Next = newNext;
            }
        }

        private Node head = null;
        public int Length { get; private set; } = 0;
        public bool IsEmpty => head == null;

        private Node FindNode(int position)
        {
            var temp = head;

            for (var i = Length - 1; ((i > position) && (i > 0)); --i)
            {
                temp = temp.Next;
            }

            return temp;
        }

        public void Insert(int newValue)
        {
            head = new Node(newValue, head);
            ++Length;
        }

        public void InsertBefore(int newValue, int nextPosition)
        {
            if (nextPosition >= Length)
            {
                Insert(newValue);
            }
            else
            {
                var nextNode = FindNode(nextPosition);
                nextNode.Next = new Node(newValue, nextNode.Next);
                ++Length;
            }
        }

        public void RemoveLast()
        {
            if (!IsEmpty)
            {
                head = head.Next;
                --Length;
            }
        }

        public void Remove(int position)
        {
            if (position >= Length - 1)
            {
                RemoveLast();
            }
            else if ((position >= 0) && (position < Length - 1))
            {
                var nextNode = FindNode(position + 1);
                nextNode.Next = nextNode.Next?.Next;
                --Length;
            }
        }

        public int this[int position]
        {
            get => FindNode(position)?.Value ?? -1;

            set
            {
                if (!IsEmpty)
                {
                    FindNode(position).Value = value;
                }
            }
        }

        public bool Exists(int value, out int position)
        {
            var temp = head;

            for (var i = Length; i > 0; --i)
            {
                if (temp.Value == value)
                {
                    position = i - 1;
                    return true;
                }
            }

            position = -1;
            return false;
        }

        public void PrintStatus()
        {
            Console.WriteLine($"Is list empty? : {IsEmpty}.");
            Console.WriteLine($"List contains {Length} elements.");
            Console.Write($"List elements: ");

            for (var i = 0; i < Length; ++i)
            {
                Console.Write($"{this[i]} ");
            }

            Console.WriteLine("\n");
        }
    }
}
