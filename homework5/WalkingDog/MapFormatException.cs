using System;

namespace WalkingDog
{
    /// <summary>
    /// Exception thrown in the case of wrong map file format.
    /// </summary>
    [Serializable]
    public class MapFormatException : Exception
    {
        public MapFormatException() { }
        public MapFormatException(string message) : base(message) { }
        public MapFormatException(string message, Exception inner) : base(message, inner) { }
        protected MapFormatException(System.Runtime.Serialization.SerializationInfo info,
                System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}