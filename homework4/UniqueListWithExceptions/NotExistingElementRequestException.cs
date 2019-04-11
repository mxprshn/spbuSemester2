using System;

namespace UniqueListWithExceptions
{
    /// <summary>
    /// Exception thrown when not existing element of list is requested.
    /// </summary>
    [Serializable]
    public class NotExistingElementRequestException : InvalidOperationException
    {
        public NotExistingElementRequestException() { }
        public NotExistingElementRequestException(string message) : base(message) { }
        public NotExistingElementRequestException(string message, Exception inner) : base(message, inner) { }
        protected NotExistingElementRequestException(System.Runtime.Serialization.SerializationInfo info,
                System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}