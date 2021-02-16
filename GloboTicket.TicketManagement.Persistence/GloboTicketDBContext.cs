using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GloboTicket.TicketManagement.Domain.Common;
using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GloboTicket.TicketManagement.Persistence
{
    public class GloboTicketDBContext : DbContext
    {
        private readonly IDomainEventDispatcher _dispatcher;

        public GloboTicketDBContext(DbContextOptions<GloboTicketDBContext> options, IDomainEventDispatcher dispatcher) : base(options)
        {
            _dispatcher = dispatcher;
        }

        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GloboTicketDBContext).Assembly);
            
        }
        
        public override int SaveChanges()
        {
            _preSaveChanges().GetAwaiter().GetResult();
            var res = base.SaveChanges();
            return res;
        }
        
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            await _preSaveChanges(); 
            
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
                
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
         private async Task _preSaveChanges()
         {
             await _dispatchDomainEvents();
         }
         
         private async Task _dispatchDomainEvents()
         {
             var domainEventEntities = ChangeTracker.Entries<Entity>()
                 .Select(po => po.Entity)
                 .Where(po => po.DomainEvents.Any())
                 .ToArray();
         
             foreach (var entity in domainEventEntities)
             {
                 IDomainEvent dev;
                 while (entity.DomainEvents.TryTake(out dev))
                     await _dispatcher.Dispatch(dev);
             }
         }
    }
}