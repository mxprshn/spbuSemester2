using System;

namespace StackCalculator
{
    /// <summary>
    /// Class with implementation of LIFO data structure of integer values.
    /// </summary>
    public class ArrayStack : IStack
    {
        private const int StartSize = 2;
        private int[] elements = new int[StartSize];
        private int pushPosition;

        /// <summary>
        /// Existence of elements in the stack.
        /// </summary>
        public bool IsEmpty => pushPosition == 0;

        /// <summary>
        /// Adds a new element to the top of the stack.
        /// </summary>
        /// <param name="data">An integer value to add.</param>
        public void Push(int data)
        {
            if (pushPosition >= elements.Length)
            {
                Array.Resize(ref elements, elements.Length * 2);
            }

            elements[pushPosition] = data;
            ++pushPosition;
        }

        /// <summary>
        /// Returns and removes the top element of the stack.
        /// </summary>
        /// <param name="isSuccessful">True if the stack had at least one element, False if it is empty.</param>
        /// <returns>Value of the top element if it existed, -1 otherwise.</returns>
        public int Pop(out bool isSuccessful)
        {
            var result = Peek(out isSuccessful);

            if (isSuccessful)
            {
                --pushPosition;
                elements[pushPosition] = 0;
            }

            return result;
        }

        /// <summary>
        /// Returns the top element of the stack.
        /// </summary>
        /// <param name="isSuccessful">True if the stack has at least one element, False if it is empty.</param>
        /// <returns>Value of the top element if it existed, -1 otherwise.</returns>
        public int Peek(out bool isSuccessful)
        {
            if (IsEmpty)
            {
                isSuccessful = false;
                return -1;
            }

            isSuccessful = true;
            return elements[pushPosition - 1];
        }

        /// <summary>
        /// Removes all elements from the stack.
        /// </summary>
        public void Clear()
        {
            Array.Clear(elements, 0, pushPosition);
            pushPosition = 0;
        }
    }
}
