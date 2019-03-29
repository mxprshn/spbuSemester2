using System;

namespace UniqueListWithExceptions
{
    /// <summary>
    /// Exception thrown when an existing value is inserted to UniqueList.
    /// </summary>
    [Serializable]
    public class ExistingElementInsertionException : InvalidOperationException
    {
        public ExistingElementInsertionException() { }
        public ExistingElementInsertionException(string message) : base(message) { }
        public ExistingElementInsertionException(string message, Exception inner) : base(message, inner) { }
        protected ExistingElementInsertionException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
