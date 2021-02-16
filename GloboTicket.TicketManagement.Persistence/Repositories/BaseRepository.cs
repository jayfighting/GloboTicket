using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GlobalTicket.TicketManagement.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GloboTicket.TicketManagement.Persistence.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        private readonly GloboTicketDBContext _dbContext;

        public BaseRepository(GloboTicketDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> GetIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}