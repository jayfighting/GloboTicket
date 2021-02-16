using System;
using GloboTicket.TicketManagement.Domain.Common;

namespace GloboTicket.TicketManagement.Domain.Entities
{
    public class Event : AuditableEntity
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        
    }
}