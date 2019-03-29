using System;

namespace UniqueListWithExceptions
{
    /// <summary>
    /// Exception thrown when an element of list with incorrect index is requested.
    /// </summary>
    [Serializable]
    public class IncorrectIndexException : ArgumentOutOfRangeException
    {
        public IncorrectIndexException() { }
        public IncorrectIndexException(string message) : base(message) { }
        public IncorrectIndexException(string message, Exception inner) : base(message, inner) { }
        protected IncorrectIndexException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}