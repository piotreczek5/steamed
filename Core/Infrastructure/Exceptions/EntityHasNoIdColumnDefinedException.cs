using System;
using System.Runtime.Serialization;

namespace Core.Generics
{
    [Serializable]
    internal class EntityDoesNotHaveColumnDefinedException : Exception
    {
        public EntityDoesNotHaveColumnDefinedException()
        {
        }

        public EntityDoesNotHaveColumnDefinedException(string message) : base(message)
        {
        }

        public EntityDoesNotHaveColumnDefinedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EntityDoesNotHaveColumnDefinedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}