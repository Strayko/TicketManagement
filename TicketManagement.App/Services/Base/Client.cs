using System.Net.Http;
using TicketManagement.App.Services.Base;

namespace TicketManagement.App.Services.Base
{
    public partial class Client : IClient
    {
        public HttpClient HttpClient
        {
            get
            {
                return _httpClient;
            }
        }
    }
}