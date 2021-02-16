using System;

namespace GloboTicket.TicketManagement.Domain.Common
{
    public class AuditableEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        
    }
}