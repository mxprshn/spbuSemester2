using System;

namespace UniqueListWithExceptions
{
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
