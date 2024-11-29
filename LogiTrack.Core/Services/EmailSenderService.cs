using LogiTrack.Core.Contracts;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;


namespace LogiTrack.Core.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly string _apiKey;

        public EmailSenderService(IConfiguration configuration)
        {
            _apiKey = configuration["SendGrid:ApiKey"];
        }

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            var client = new SendGridClient(_apiKey);
            var from = new EmailAddress("no-reply@logitrack.com", "LogiTrack");
            var to = new EmailAddress(toEmail);
            var emailMessage = MailHelper.CreateSingleEmail(from, to, subject, message, message);

            await client.SendEmailAsync(emailMessage);
        }
    }
}
