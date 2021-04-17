using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;

namespace TicketManagement.Api.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}