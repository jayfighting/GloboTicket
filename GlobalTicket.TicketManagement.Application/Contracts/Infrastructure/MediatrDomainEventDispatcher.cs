using System;
using System.Threading.Tasks;
using GloboTicket.TicketManagement.Domain.Common;
using MediatR;
using Microsoft.Extensions.Logging;

namespace GlobalTicket.TicketManagement.Application.Contracts.Infrastructure
{
    public class MediatrDomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IMediator _mediator;
        private readonly ILogger<MediatrDomainEventDispatcher> _logger;
        
        public MediatrDomainEventDispatcher(IMediator mediator, ILogger<MediatrDomainEventDispatcher> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public async Task Dispatch(IDomainEvent @event)
        {
            var domainEventNotification = CreateDomainEventNotification(@event);
            _logger.LogDebug("Dispatching domain event as MediatR notification. Event Type {eventType}", @event.GetType());
            await _mediator.Publish(domainEventNotification);
        }

        private INotification CreateDomainEventNotification(IDomainEvent @event)
        {
            var genericDispatchType = typeof(DomainEventNotification<>).MakeGenericType(@event.GetType());
            return (INotification) Activator.CreateInstance(genericDispatchType, @event);
        } 
    }
}