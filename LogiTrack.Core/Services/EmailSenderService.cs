using LogiTrack.Core.Contracts;
using MailKit.Net.Smtp;
using MimeKit;


namespace LogiTrack.Core.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly string smtpServer = "smtp.gmail.com";
        private readonly int port = 587;
        private readonly string username = "infiniabank@gmail.com";
        private readonly string password = "lhna tdvn dacn nqud";

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Infinia Bank", username));
            emailMessage.To.Add(new MailboxAddress("", toEmail));
            emailMessage.Subject = subject;

            var bodyBuilder = new BodyBuilder { HtmlBody = body };
            emailMessage.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                await client.ConnectAsync(smtpServer, port, MailKit.Security.SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(username, password);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
    }
}
