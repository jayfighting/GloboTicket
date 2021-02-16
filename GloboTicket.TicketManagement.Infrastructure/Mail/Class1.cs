using System.Net;
using System.Threading.Tasks;
using GlobalTicket.TicketManagement.Application.Contracts.Infrastructure;
using GlobalTicket.TicketManagement.Application.Models.Mail;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace GloboTicket.TicketManagement.Infrastructure.Mail
{
    public class EmailServices : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailServices(IOptions<EmailSettings> mailSettings)
        {
            _emailSettings = mailSettings.Value;
        } 
        public async Task<bool> SendEmail(Email email)
        {
            var client = new SendGridClient(_emailSettings.ApiKey);
            var subject = email.Subject;
            var to = new EmailAddress(email.To);
            var emailBody = email.Body;
            var from = new EmailAddress()
            {
                Email = _emailSettings.FromAddress,
                Name = _emailSettings.FromName
            };
            
            var message = MailHelper.CreateSingleEmail(from, to, subject, emailBody, emailBody);
            var response = await client.SendEmailAsync(message);

            if (response.StatusCode == HttpStatusCode.Accepted || response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }

            return false;
        }
    }
}