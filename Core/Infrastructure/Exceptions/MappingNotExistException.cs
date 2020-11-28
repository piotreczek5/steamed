using System;
using System.Runtime.Serialization;

namespace Core.Infrastructure
{
    [Serializable]
    internal class MappingNotExistException : Exception
    {
        public MappingNotExistException()
        {
        }

        public MappingNotExistException(string message) : base(message)
        {
        }

        public MappingNotExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MappingNotExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}