using Microsoft.AspNetCore.Builder;

namespace TicketManagement.Api.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExtensionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<>();
        }
    }
}