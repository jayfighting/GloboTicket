using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GlobalTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GlobalTicket.TicketManagement.Application.Features.Events.Queries.GetCategoriesList
{
    public class GetCategoriesListQueryHandler : IRequestHandler<GetCategoriesListQuery, List<GetCategoriesListVM>>
    {
        public GetCategoriesListQueryHandler(IMapper mapper, IAsyncRepository<Category> asyncRepository)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<GetCategoriesListVM>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}