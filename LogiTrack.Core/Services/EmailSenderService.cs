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
                var from = new EmailAddress("yoana.yotova03@gmail.com", "LogiTrack");

                var replyTo = new EmailAddress("yoana.yotova03@gmail.com");

                var to = new EmailAddress(toEmail);

                var emailMessage = MailHelper.CreateSingleEmail(from, to, subject, message, message);
                emailMessage.ReplyTo = replyTo; 

                var client = new SendGridClient(_apiKey);
                var response = await client.SendEmailAsync(emailMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
            }
        }
    }
}
