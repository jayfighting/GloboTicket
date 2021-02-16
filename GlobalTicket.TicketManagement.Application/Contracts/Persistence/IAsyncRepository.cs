using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlobalTicket.TicketManagement.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T: class
    {
        Task<T> GetIdAsync(Guid id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        
         

    }
}