using System.Collections.Generic;
using MediatR;

namespace TicketManagement.Application.Features.Events.Queries.GetEventsList
{
    public class GetEventListQuery : IRequest<List<EventListVm>>
    {
        
    }
}