using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace StreamerSite.API.ExceptionHandler
{
    public class ErrorHandler
    {
        private readonly RequestDelegate next;

        public ErrorHandler(RequestDelegate request)
        {
            next = request;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                await HandleException(context, e);
            }
        }

        private static Task HandleException(HttpContext context, Exception e)
        {
            var code = HttpStatusCode.InternalServerError;

            if (e is UnauthorizedAccessException)
                code = HttpStatusCode.Unauthorized;

            var result = JsonConvert.SerializeObject(new { error = e.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }
    }
}
