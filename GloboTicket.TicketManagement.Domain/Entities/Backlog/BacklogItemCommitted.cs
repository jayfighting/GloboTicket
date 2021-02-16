using System;
using GloboTicket.TicketManagement.Domain.Common;

namespace GloboTicket.TicketManagement.Domain.Entities.Backlog
{
    public class BacklogItemCommitted : IDomainEvent
    {
            public Guid BacklogItemId { get; }
            public Guid SprintId { get; set; }
            public DateTime CreatedAtUtc { get; }
    
            private BacklogItemCommitted() { }
    
            public BacklogItemCommitted(BacklogItem b, Sprint s)
            {
                this.BacklogItemId = b.Id;
                this.CreatedAtUtc = b.CreatedAtUtc;
                this.SprintId = s.Id;
            }    
    }
}