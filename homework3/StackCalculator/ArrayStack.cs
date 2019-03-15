using System;

namespace StackCalculator
{
    /// <summary>
    /// Class with implementation of LIFO data structure with integer values.
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
        /// <returns>Value of the top element.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the stack is empty.</exception>
        public int Pop()
        {
            var result = Peek();
            --pushPosition;
            elements[pushPosition] = 0;
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
