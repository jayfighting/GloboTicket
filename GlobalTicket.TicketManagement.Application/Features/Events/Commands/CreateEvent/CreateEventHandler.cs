using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GlobalTicket.TicketManagement.Application.Contracts.Infrastructure;
using GlobalTicket.TicketManagement.Application.Contracts.Persistence;
using GlobalTicket.TicketManagement.Application.Exceptions;
using GlobalTicket.TicketManagement.Application.Models.Mail;
using MediatR;

namespace GlobalTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private IEventRepository _eventRepository;
        private readonly IEmailService _emailService;
        private IMapper _mapper;

        public CreateEventHandler(IMapper mapper, IEventRepository eventRepository, IEmailService emailService)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
            _emailService = emailService;
        }

        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateEventCommandValidator(_eventRepository);
            var validateResult = await validator.ValidateAsync(request);
            if (validateResult.Errors.Count > 0)
            {
                throw new ValidationException(validateResult);
            }

            var email = new Email();

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            return Guid.Empty;
        }
    }
}