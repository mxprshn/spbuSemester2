using System;

namespace UniqueListWithExceptions
{
    [Serializable]
    public class NotExistingElementRemovalException : InvalidOperationException
    {
        public NotExistingElementRemovalException() { }
        public NotExistingElementRemovalException(string message) : base(message) { }
        public NotExistingElementRemovalException(string message, Exception inner) : base(message, inner) { }
        protected NotExistingElementRemovalException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
