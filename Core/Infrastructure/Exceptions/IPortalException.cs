using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Steamed.Core.Infrastructure.Exceptions
{
    public interface IPortalException
    {
        HttpStatusCode StatusCode { get; }
    }
}
