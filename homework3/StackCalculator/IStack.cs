﻿
namespace StackCalculator
{
    /// <summary>
    /// Interface of LIFO data structure with integer values.
    /// </summary>
    public interface IStack
    {
        /// <summary>
        /// Existence of elements in the stack.
        /// </summary>
        bool IsEmpty { get; }

        /// <summary>
        /// Adds a new element to the top of the stack.
        /// </summary>
        /// <param name="data">An integer value to add.</param>
        void Push(int data);

        /// <summary>
        /// Returns and removes the top element of the stack.
        /// </summary>
        /// <returns>Value of the top element.</returns>
        int Pop();

        /// <summary>
        /// Returns the top element of the stack.
        /// </summary>
        /// <returns>Value of the top element.</returns>
        int Peek();

        /// <summary>
        /// Removes all elements from the stack.
        /// </summary>
        void Clear();
    }
}
