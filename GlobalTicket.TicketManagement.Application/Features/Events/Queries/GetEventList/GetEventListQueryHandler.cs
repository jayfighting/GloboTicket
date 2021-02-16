using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace GlobalTicket.TicketManagement.Application.Features.Events.Queries.GetEventList
{
    public class GetEventListQueryHandler : IRequestHandler<GetEventListQuery, List<EventListVM>>
    {
        public Task<List<EventListVM>> Handle(GetEventListQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}