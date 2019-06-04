using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

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

        /// <summary>
        /// Gets the number of elements contained in the set.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the set is read-only.
        /// </summary>
        public bool IsReadOnly { get; } = false;

        /// <summary>
        /// Determines whether the set contains a specific value.
        /// </summary>
        /// <param name="targetValue">The object to locate in the set.</param>
        /// <returns>True if item is found in the set; otherwise, false.</returns>
        public bool Contains(T targetValue) => FindNode(targetValue) != null;

        /// <summary>
        /// Adds an element to the current set and returns a value to indicate if the element was successfully added.
        /// </summary>
        /// <param name="newValue">The element to add to the set.</param>
        /// <returns>True if the element is added to the set; false if the element is already in the set.</returns>
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

            var possibleParent = root;
            var isLeft = newValue.CompareTo(root.Value) < 0;

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

        /// <summary>
        /// Adds an item to the set.
        /// </summary>
        /// <param name="newValue">The item to add to the set.</param>
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

        /// <summary>
        /// Removes a specific object from the set.
        /// </summary>
        /// <param name="targetValue">The object to remove from the set.</param>
        /// <returns>True if item was successfully removed from the set; otherwise, false.</returns>
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

        private Node Minimum(Node start) => start.LeftChild == null ? start : Minimum(start.LeftChild);

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

        /// <summary>
        /// Removes all items from the set.
        /// </summary>
        public void Clear()
        {
            Count = 0;
            root = null;
        }

        /// <summary>
        /// Copies the elements of the set to an Array, starting at a particular Array index.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination
        ///     of the elements copied from set.
        /// </param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        /// <exception cref="ArgumentOutOfRangeException">ArrayIndex is less than 0.</exception>
        /// <exception cref="ArgumentNullException">Array is null.</exception>
        /// <exception cref="ArgumentException">The number of elements in the source
        ///     set is greater than the available space from arrayIndex to the end of the
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
        /// Modifies the current set so that it contains all elements that are present in
        ///     the current set, in the specified collection, or in both.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        /// <exception cref="ArgumentNullException">Other is null.</exception>
        public void UnionWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var current in other)
            {
                _ = Add(current);
            }
        }

        /// <summary>
        /// Modifies the current set so that it contains only elements that are also in a specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        /// <exception cref="ArgumentNullException">Other is null.</exception>
        public void IntersectWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException();
            }

            var toRemove = new List<T>();

            foreach (var current in this)
            {
                if (!other.Contains(current))
                {
                    toRemove.Add(current);
                }
            }

            ExceptWith(toRemove);
        }

        /// <summary>
        /// Removes all elements in the specified collection from the current set.
        /// </summary>
        /// <param name="other">The collection of items to remove from the set.</param>
        /// <exception cref="ArgumentNullException">Other is null.</exception>
        public void ExceptWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var current in other)
            {
                Remove(current);
            }
        }

        /// <summary>
        /// Modifies the current set so that it contains only elements that
        ///     are present either in the current set or in the specified collection, but not both.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        /// <exception cref="ArgumentNullException">Other is null.</exception>
        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException();
            }

            var intersection = new Set<T>();
            intersection.UnionWith(this);
            intersection.IntersectWith(other);
            UnionWith(other);
            ExceptWith(intersection);
        }

        /// <summary>
        /// Determines whether a set is a subset of a specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        /// <returns>True if the current set is a subset of other; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException">Other is null.</exception>
        public bool IsSubsetOf(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var current in this)
            {
                if (!other.Contains(current))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Determines whether a set is a superset of a specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        /// <returns>True if the current set is a superset of other; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException">Other is null.</exception>
        public bool IsSupersetOf(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var current in other)
            {
                if (!Contains(current))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Determines whether a set is a proper subset of a specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        /// <returns>True if the current set is a proper subset of other; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException">Other is null.</exception>
        public bool IsProperSubsetOf(IEnumerable<T> other) => IsSubsetOf(other) && !IsSupersetOf(other);

        /// <summary>
        /// Determines whether a set is a proper superset of a specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        /// <returns>True if the current set is a proper superset of other; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException">Other is null.</exception>
        public bool IsProperSupersetOf(IEnumerable<T> other) => !IsSubsetOf(other) && IsSupersetOf(other);

        /// <summary>
        /// Determines whether the current set and the specified collection contain the same elements.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        /// <returns>True if the current set is equal to other; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException">Other is null.</exception>
        public bool SetEquals(IEnumerable<T> other) => IsSubsetOf(other) && IsSupersetOf(other);

        /// <summary>
        /// Determines whether the current set overlaps with the specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        /// <returns>True if the current set and other share at least one common element; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException">Other is null.</exception>
        public bool Overlaps(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var current in this)
            {
                if (other.Contains(current))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the set and returns elements in ascending order.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            var nodeStack = new Stack<Node>();
            var current = root;

            while (nodeStack.Count > 0 || current != null)
            {
                if (current == null)
                {
                    current = nodeStack.Pop();
                    yield return current.Value;
                    current = current.RightChild;
                }
                else
                {
                    nodeStack.Push(current);
                    current = current.LeftChild;
                }
            }

            yield break;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the set and returns elements in ascending order.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}