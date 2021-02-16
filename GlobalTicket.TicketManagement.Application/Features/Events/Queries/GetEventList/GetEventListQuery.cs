using System.Collections.Generic;
using MediatR;

namespace GlobalTicket.TicketManagement.Application.Features.Events.Queries.GetEventList
{
    public class GetEventListQuery : IRequest<List<EventListVM>>
    {
        
    }
}