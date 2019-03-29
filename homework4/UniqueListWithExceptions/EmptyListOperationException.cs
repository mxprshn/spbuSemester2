using System;

namespace UniqueListWithExceptions
{
    /// <summary>
    /// Exception thrown when an operation with empty list commited.
    /// </summary>
    [Serializable]
    public class EmptyListOperationException : InvalidOperationException
    {
        public EmptyListOperationException() { }
        public EmptyListOperationException(string message) : base(message) { }
        public EmptyListOperationException(string message, Exception inner) : base(message, inner) { }
        protected EmptyListOperationException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
