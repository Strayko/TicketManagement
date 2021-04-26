using System.Net.Http;

namespace TicketManagement.App.Services.Base
{
    public partial interface IClient
    {
        public HttpClient HttpClient { get; }
    }
}