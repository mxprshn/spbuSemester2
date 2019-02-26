using System;

namespace SinglyLinkedList
{
    class List : IList
    {
        private class Node
        {
            public int Value { get; set; }
            public Node Next { get; set; }

            public Node(int newValue, Node newNext = null)
            {
                Value = newValue;
                Next = newNext;
            }
        }

        private Node head;
        public int Length { get; private set; }
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

        public void InsertFirst(int newValue)
        {
            head = new Node(newValue, head);
            ++Length;
        }

        public void InsertAfter(int newValue, int previousPosition)
        {
            var previousNode = FindNode(previousPosition);
            previousNode.Next = new Node(newValue, previousNode.Next);
            ++Length;         
        }

        public void RemoveFirst()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("The list was empty");
            }

            head = head.Next;
            --Length;
        }

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

        public int this[int position]
        {
            get => FindNode(position).Value;

            set => FindNode(position).Value = value;
        }

        public bool Exists(int value)
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

        public int FindPosition(int value)
        {
            var temp = head;

            for (var i = 0; i < Length; ++i)
            {
                if (temp.Value == value)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
