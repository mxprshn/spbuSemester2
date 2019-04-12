using System;

namespace Task1
{
    /// <summary>
    /// Exception thrown when Dequeue operation is performed with an empty queue.
    /// </summary>
    [Serializable]
    public class DequeueFromEmptyException : Exception
    {
        public DequeueFromEmptyException() { }
        public DequeueFromEmptyException(string message) : base(message) { }
        public DequeueFromEmptyException(string message, Exception inner) : base(message, inner) { }
        protected DequeueFromEmptyException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}