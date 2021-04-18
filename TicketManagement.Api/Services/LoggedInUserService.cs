using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using TicketManagement.Application.Contracts;

namespace TicketManagement.Api.Services
{
    public class LoggedInUserService : ILoggedInUserService
    {
        public string UserId { get; }

        public LoggedInUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}