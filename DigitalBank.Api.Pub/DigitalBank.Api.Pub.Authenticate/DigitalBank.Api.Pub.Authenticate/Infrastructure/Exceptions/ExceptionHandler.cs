using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.Authenticate.Infrastructure.Exceptions
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;

        /// <summary> 
        ///  
        /// </summary> 
        /// <param name="next"></param> 
        public ExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }


        /// <summary> 
        ///  
        /// </summary> 
        /// <param name="context"></param> 
        /// <param name="logger"></param> 
        /// <returns></returns> 
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        /// <summary> 
        ///  
        /// </summary> 
        /// <param name="context"></param> 
        /// <param name="exception"></param> 
        /// <returns></returns> 
        public async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            if (exception == null)
            {
                return;
            }

            var code = HttpStatusCode.InternalServerError;

            if (exception is ArgumentException)
            {
                code = HttpStatusCode.BadRequest;
            }
            else if (exception is KeyNotFoundException)
            {
                code = HttpStatusCode.NotFound;
            }
            else if (exception is UnauthorizedAccessException)
            {
                code = HttpStatusCode.Unauthorized;
            }
            else if (exception is InvalidOperationException)
            {
                code = HttpStatusCode.Unauthorized;
            }

            await WriteExceptionAsync(context, exception, code).ConfigureAwait(false);
        }

        /// <summary> 
        ///  
        /// </summary> 
        /// <param name="context"></param> 
        /// <param name="exception"></param> 
        /// <param name="code"></param> 
        /// <returns></returns> 
        private async Task WriteExceptionAsync(HttpContext context, Exception exception, HttpStatusCode code)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)code;
            await response.WriteAsync(JsonConvert.SerializeObject(exception.Message)).ConfigureAwait(false);
        }

    }
}
