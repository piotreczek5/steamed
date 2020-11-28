using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Steamed.Core.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Steamed.Core.Infrastructure.Middlewares
{
    public class ErrorToJsonExceptionHandler
    {
        private const string JSON_CONTENT_TYPE = "application/json";

        public ErrorToJsonExceptionHandler()
        {
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var contextHandler = httpContext.Features.Get<IExceptionHandlerFeature>();

            if(contextHandler != null && contextHandler.Error != null)
            {
                httpContext.Response.StatusCode = GetExceptionStatusCode(contextHandler.Error);
                httpContext.Response.ContentType = JSON_CONTENT_TYPE;

                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(new
                {
                    Status = httpContext.Response.StatusCode,
                    Message = contextHandler.Error.Message
                }));
            }
        }

        private int GetExceptionStatusCode(Exception error)
        {
            if(!typeof(IPortalException).GetType().IsAssignableFrom(error.GetType()))
            {
                return (int)HttpStatusCode.InternalServerError;
            }

            return (int)(error as IPortalException).StatusCode;
        }
    }
}
