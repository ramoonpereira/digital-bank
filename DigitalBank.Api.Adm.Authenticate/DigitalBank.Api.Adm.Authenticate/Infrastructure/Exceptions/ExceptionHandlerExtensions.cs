using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBank.Api.Adm.Authenticate.Infrastructure.Exceptions
{
    /// <summary> 
    ///  
    /// </summary> 
    public static class ExceptionHandlerExtensions
    {
        /// <summary> 
        ///  
        /// </summary> 
        /// <param name="builder"></param> 
        public static void UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ExceptionHandler>();
        }
    }
}
