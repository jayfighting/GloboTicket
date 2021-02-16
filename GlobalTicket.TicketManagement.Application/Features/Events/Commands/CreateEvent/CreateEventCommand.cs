using System;
using MediatR;

namespace GlobalTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public Decimal Price { get; set; }
    }
}