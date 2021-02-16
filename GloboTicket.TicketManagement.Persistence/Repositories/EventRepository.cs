using System;
using System.Linq;
using System.Threading.Tasks;
using GlobalTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.TicketManagement.Persistence.Repositories
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        private readonly GloboTicketDBContext _dbContext;

        public EventRepository(GloboTicketDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<bool> IsEventNameAndDateUnique(string name, DateTime date)
        {
            var matches = _dbContext.Events.Any(e => e.Name.Equals(name) && e.Date == date);
            return Task.FromResult(matches);
        }
    }
}