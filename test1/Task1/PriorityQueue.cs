
namespace Task1
{
    /// <summary>
    /// Class implementing queue FIFO data structure with priorities.
    /// </summary>
    public class PriorityQueue
    {
        private class Node
        {
            public int Value { get; }
            public int Priority { get; }
            public Node Next { get; set; }

            public Node(int priority, int value, Node next)
            {
                Priority = priority;
                Value = value;
                Next = next;
            }
        }

        private Node head;

        /// <summary>
        /// Existence of elements in the queue.
        /// </summary>
        public bool IsEmpty => head == null;
        
        /// <summary>
        /// Adds a new element to the queue.
        /// </summary>
        /// <param name="priority">Integer priority of the element.</param>
        /// <param name="value">Integer value of the element.</param>
        public void Enqueue(int priority, int value)
        {
            if (IsEmpty || priority > head.Priority)
            {
                head = new Node(priority, value, head);
                return;
            }

            var previous = head;

            while (previous.Next != null && priority <= previous.Next.Priority)
            {
                previous = previous.Next;
            }

            previous.Next = new Node(priority, value, previous.Next);
        }

        /// <summary>
        /// Returns the value of the first added element with the highest priority and removes it from the queue.
        /// </summary>
        /// <returns>Value of the first added element with the highest priority.</returns>
        /// <exception cref="DequeueFromEmptyException">Thrown when the queue is empty.</exception>
        public int Dequeue()
        {
            if (IsEmpty)
            {
                throw new DequeueFromEmptyException();
            }

            var result = head.Value;
            head = head.Next;
            return result;
        }
    }
}