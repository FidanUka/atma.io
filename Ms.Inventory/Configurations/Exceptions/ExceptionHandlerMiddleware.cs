using Microsoft.AspNetCore.Http;
using Ms.Inventory.Shared.Exceptions;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ms.Inventory.Configurations.Exceptions
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context).ConfigureAwait(true);
            }
            catch(TagValidationException ex)
            {
                await HandleTagValidationExceptionMessageAsync(context, ex).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                await HandleExceptionMessageAsync(context, ex).ConfigureAwait(false);
            }
        }

        private static Task HandleTagValidationExceptionMessageAsync(HttpContext context, TagValidationException exception)
        {
            int statusCode = (int)HttpStatusCode.BadRequest;

            var result = JsonSerializer.Serialize(new
            {
                exception.Message
            }, new JsonSerializerOptions { WriteIndented = false });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            return context.Response.WriteAsync(result);
        }

        private static Task HandleExceptionMessageAsync(HttpContext context, Exception exception)
        {
            int statusCode = (int)HttpStatusCode.InternalServerError;

            var result = JsonSerializer.Serialize(new
            {
                ErrorMessage = exception.Message
            }, new JsonSerializerOptions { WriteIndented = false });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            return context.Response.WriteAsync(result);
        }
    }
}
