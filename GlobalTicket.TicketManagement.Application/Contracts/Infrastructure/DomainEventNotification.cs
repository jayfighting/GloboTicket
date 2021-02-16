using GloboTicket.TicketManagement.Domain.Common;
using MediatR;

namespace GlobalTicket.TicketManagement.Application.Contracts.Infrastructure
{
    // wrapper for domain event to work with MediatR, wrap it into Inotification
    public class DomainEventNotification<TDomainEvent> : INotification where TDomainEvent : IDomainEvent
    {
        public TDomainEvent DomainEvent { get; }

        public DomainEventNotification(TDomainEvent domainEvent)
        {
            DomainEvent = domainEvent;
        }
    }
}