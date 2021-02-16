using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Domain.Common
{
    public interface IDomainEventDispatcher
    {
        Task Dispatch(IDomainEvent @event);
    }
}