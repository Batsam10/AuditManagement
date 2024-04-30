
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AuditManagement.WebAPI.Helpers
{
    public static class ExceptionHandler
    {
        public async static Task HandleException(HttpContext context, ILogger<Program>? logger)
        {
            var exceptionHandlerPathFeature =
                        context.Features.Get<IExceptionHandlerPathFeature>();

            var reference = Guid.NewGuid();

            var exception = exceptionHandlerPathFeature?.Error;
            logger?.LogError($"Reference '{reference}': An error occurred. ");

            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            string title = "Internal server error";
            var details = $" Contact administrator with reference: {reference}";

            switch (exception)
            {
                case UnauthorizedAccessException:
                    statusCode = HttpStatusCode.Unauthorized;
                    title = "Authorization error";
                    break;

                case InvalidOperationException:
                    statusCode = HttpStatusCode.BadRequest;
                    title = "Invalid operation error";
                    break;

                case ArgumentException:
                    statusCode = HttpStatusCode.BadRequest;
                    title = "Argument error";
                    break;

                case KeyNotFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    title = "Key not found error";
                    break;

                default:
                    break;
            }

            int status = (int)statusCode;
            context.Response.StatusCode = status;

            await context.Response.WriteAsJsonAsync(new ProblemDetails()
            {
                Status = status,
                Title = title,
                Detail = details
            });
        }
    }
}
