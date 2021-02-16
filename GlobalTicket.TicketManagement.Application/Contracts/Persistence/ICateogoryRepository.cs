using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GloboTicket.TicketManagement.Domain.Entities;

namespace GlobalTicket.TicketManagement.Application.Contracts.Persistence
{
    public class ICateogoryRepository : IAsyncRepository<Category>
    {
        public Task<Category> GetIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Category>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Category> AddAsync(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}