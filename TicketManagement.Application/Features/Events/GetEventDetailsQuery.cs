using System;
using MediatR;

namespace TicketManagement.Application.Features.Events
{
    public class GetEventDetailsQuery : IRequest<EventDetailVm>
    {
        public Guid Id { get; set; }
    }
}