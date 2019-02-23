using System;

namespace SinglyLinkedList
{
    class List : IList
    {
        private class Node
        {
            public Tuple<string, string> Data { get; set; }
            public Node Next { get; set; }

            public Node(string key, string value, Node newNext)
            {
                Data = new Tuple<string, string>(key, value);
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

        private Node FindNode(string key)
        {
            var temp = head;

            for (var i = 0; i < Length; ++i)
            {
                if (temp.Data.Item1 != key)
                {
                    temp = temp.Next;
                }
                else
                {
                    return temp;
                }
            }

            return temp;
        }

        public void Insert(string key, string value)
        {
            head = new Node(key, value, head);
            ++Length;
        }

        public void InsertBefore(string key, string value, int nextPosition)
        {
            if (nextPosition >= Length)
            {
                Insert(key, value);
            }
            else
            {
                var nextNode = FindNode(nextPosition);
                nextNode.Next = new Node(key, value, nextNode.Next);
                ++Length;
            }
        }

        public void InsertAfter(string key, string value, int previousPosition)
        {
            InsertBefore(key, value, previousPosition + 1);
        }

        public void Remove()
        {
            if (!IsEmpty)
            {
                head = head.Next;
                --Length;
            }            
        }

        public void RemoveBefore(int nextPosition)
        {
            if (nextPosition == Length)
            {
                Remove();
            }
            else if ((nextPosition > 0) && (nextPosition < Length))
            {
                var nextNode = FindNode(nextPosition);
                nextNode.Next = nextNode.Next?.Next;
                --Length;
            }
        }

        public void RemoveAfter(int previousPosition)
        {
            RemoveBefore(previousPosition + 2);
        }

        public string this[int position]
        {
            get => FindNode(position)?.Data.Item2;

            set
            {
                if (!IsEmpty)
                {
                    var targetNode = FindNode(position);
                    targetNode.Data = new Tuple<string, string>(targetNode.Data.Item1, value);
                }                
            }
        }

        public string this[string key]
        {
            get => FindNode(key)?.Data.Item2;

            set
            {
                if (!IsEmpty)
                {
                    var targetNode = FindNode(key);
                    targetNode.Data = new Tuple<string, string>(targetNode.Data.Item1, value);
                }
            }
        }

    }
}
