using Steamed.Core.Infrastructure.Exceptions;
using System;
using System.Net;
using System.Runtime.Serialization;

namespace Core.Generics
{
    [Serializable]
    internal class EntityNotFoundException : Exception, IPortalException
    {
        public EntityNotFoundException()
        {
        }

        public EntityNotFoundException(string message) : base(message)
        {
        }

        public EntityNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EntityNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public HttpStatusCode StatusCode => HttpStatusCode.NotFound;
    }
}