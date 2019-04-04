using System;

namespace StackCalculator
{
    /// <summary>
    /// Class with implementation of LIFO data structure with integer values.
    /// </summary>
    public class ListStack : IStack
    {
        private class StackElement
        {
            public int Data { get; }
            public StackElement Next { get; }

            public StackElement(int data, StackElement next)
            {
                Data = data;
                Next = next;
            }
        }

        private StackElement head;

        /// <summary>
        /// Existence of elements in the stack.
        /// </summary>
        public bool IsEmpty => head == null;

        /// <summary>
        /// Adds a new element to the top of the stack.
        /// </summary>
        /// <param name="data">An integer value to add.</param>
        public void Push(int data) => head = new StackElement(data, head);

        /// <summary>
        /// Returns and removes the top element of the stack.
        /// </summary>
        /// <returns>Value of the top element.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the stack is empty.</exception>
        public int Pop()
        {
            var result = Peek();
            head = head.Next;
            return result;
        }

        /// <summary>
        /// Returns the top element of the stack.
        /// </summary>
        /// <returns>Value of the top element.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the stack is empty.</exception>
        public int Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException();
            }

            return head.Data;
        }

        /// <summary>
        /// Removes all elements from the stack.
        /// </summary>
        public void Clear()
        {
            head = null;
        }
    }
}
