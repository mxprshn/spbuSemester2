using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericSet
{
    public class Set<T> : ISet<T> where T : IComparable<T>
    {
        private class Node
        {
            public T Value { get; set; }
            public Node Parent { get; set; }
            public Node LeftChild { get; set; }
            public Node RightChild { get; set; }

            public Node(T newValue, Node newParent, Node newLeftChild = null, Node newRightChild = null)
            {
                Value = newValue;
                Parent = newParent;
                LeftChild = newLeftChild;
                RightChild = newRightChild;
            }
        }

        private Node root;

        public int Count { get; private set; }

        public bool IsReadOnly { get; } = false;

        public bool Contains(T targetValue) => FindNode(targetValue) != null;

        public bool Add(T newValue)
        {
            if (Contains(newValue))
            {
                return false;
            }

            if (Count == 0)
            {
                root = new Node(newValue, null);
                ++Count;
                return true;
            }

            Node possibleParent = root;
            bool isLeft = newValue.CompareTo(root.Value) < 0;

            while (isLeft && possibleParent.LeftChild != null || !isLeft && possibleParent.RightChild != null)
            {
                possibleParent = isLeft ? possibleParent.LeftChild : possibleParent.RightChild;
                isLeft = newValue.CompareTo(possibleParent.Value) < 0;
            }

            if (isLeft)
            {
                possibleParent.LeftChild = new Node(newValue, possibleParent);
            }
            else
            {
                possibleParent.RightChild = new Node(newValue, possibleParent);
            }

            ++Count;
            return true;
        }

        void ICollection<T>.Add(T newValue) => _ = Add(newValue);

        private Node FindNode(T targetValue)
        {
            var temp = root;

            while (temp != null && !targetValue.Equals(temp.Value))
            {
                temp = targetValue.CompareTo(temp.Value) < 0 ? temp.LeftChild : temp.RightChild;
            }

            return temp;
        }

        public bool Remove(T targetValue)
        {
            var targetNode = FindNode(targetValue);

            if (targetNode == null)
            {
                return false;
            }

            if (targetNode.LeftChild == null)
            {
                Transplant(targetNode, targetNode.RightChild);
            }
            else if (targetNode.RightChild == null)
            {
                Transplant(targetNode, targetNode.LeftChild);
            }
            else
            {
                var rightMinimum = Minimum(targetNode.RightChild);

                if (!targetNode.Equals(rightMinimum.Parent))
                {
                    Transplant(rightMinimum, rightMinimum.RightChild);
                    rightMinimum.RightChild = targetNode.RightChild;
                    rightMinimum.RightChild.Parent = rightMinimum;
                }

                Transplant(targetNode, rightMinimum);

                rightMinimum.LeftChild = targetNode.LeftChild;
                rightMinimum.LeftChild.Parent = rightMinimum;
            }

            --Count;
            return true;
        }

        private Node Minimum(Node start)
        {
            return start.LeftChild == null ? start : Minimum(start.LeftChild);
        }

        private void Transplant(Node target, Node source)
        {
            if (target.Parent == null)
            {
                root = source;
            }
            else if (target.Equals(target.Parent.LeftChild))
            {
                target.Parent.LeftChild = source;
            }
            else
            {
                target.Parent.RightChild = source;
            }

            if (source != null)
            {
                source.Parent = target.Parent;
            }
        }

        public void Clear()
        {
            Count = 0;
            root = null;
        }

        private class TreeTraverser : IEnumerator<T>
        {

        }

        public IEnumerator<T> GetEnumerator() => new TreeTraverser();
    }
}
