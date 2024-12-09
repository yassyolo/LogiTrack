using LogiTrack.Core.Contracts;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;


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
            try
            {
                var client = new SendGridClient(_apiKey);
                var from = new EmailAddress("no-reply@logitrack.com", "LogiTrack");
                var to = new EmailAddress(toEmail);
                var emailMessage = MailHelper.CreateSingleEmail(from, to, subject, message, message);

                var response = await client.SendEmailAsync(emailMessage);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception($"Email not sent. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
            }
        }
    }
}
