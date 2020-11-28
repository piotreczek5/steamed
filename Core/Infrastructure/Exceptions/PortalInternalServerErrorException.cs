using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Steamed.Core.Infrastructure.Exceptions
{
    public class PortalInternalServerErrorException : Exception, IPortalException
    {
        public PortalInternalServerErrorException(string message) : base(message)
        {
        }

        public HttpStatusCode StatusCode => HttpStatusCode.InternalServerError;
    }
}
