using System.Collections.Generic;
using MediatR;

namespace TicketManagement.Application.Features.Events
{
    public class GetEventListQuery : IRequest<List<EventListVm>>
    {
        
    }
}