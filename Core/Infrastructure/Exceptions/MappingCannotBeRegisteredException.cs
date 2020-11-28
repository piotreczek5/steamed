using System;
using System.Runtime.Serialization;

namespace Core.Infrastructure
{
    [Serializable]
    internal class MappingCannotBeRegisteredException : Exception
    {
        public MappingCannotBeRegisteredException()
        {
        }

        public MappingCannotBeRegisteredException(string message) : base(message)
        {
        }

        public MappingCannotBeRegisteredException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MappingCannotBeRegisteredException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}