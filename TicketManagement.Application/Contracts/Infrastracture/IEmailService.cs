using System.Threading.Tasks;
using TicketManagement.Application.Models.Mail;

namespace TicketManagement.Application.Contracts.Infrastracture
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}