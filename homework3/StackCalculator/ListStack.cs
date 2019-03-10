
namespace StackCalculator
{
    /// <summary>
    /// Class with implementation of LIFO data structure of integer values.
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
        public void Push(int data)
        {
            head = new StackElement(data, head);
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
                head = head.Next;
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
            return head.Data;
        }

        /// <summary>
        /// Removes all elements from the stack.
        /// </summary>
        public void Clear()
        {
            while (!IsEmpty)
            {
                _ = Pop(out _);
            }
        }
    }
}
