using System;

namespace SinglyLinkedList
{
    class List
    {
        private class Node
        {
            public int Value { get; }
            public Node Next { get; set; }

            public Node(int newValue, Node newNext)
            {
                Value = newValue;
                Next = newNext;
            }
        }

        private Node head = null;
        public int Length { get; private set; } = 0;

        public bool IsEmpty()
        {
            return head == null;
        }

        private Node FindNode(int position)
        {
            var temp = head;

            for (var i = Length - 1; i > position; --i)
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

        public void InsertNext(int newValue, int previousPosition)
        {

        }

        public void Remove()
        {
            head = head.Next;
        }


    }
}
