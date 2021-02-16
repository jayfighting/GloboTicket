using GlobalTicket.TicketManagement.Application.Features;
using GlobalTicket.TicketManagement.Application.Features.Events.Queries.GetEventList;

namespace GlobalTicket.TicketManagement.Application.Profile
{
    public class MappingProfile: AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<EventListVM, EventListVM>().ReverseMap();
        }
    }
}