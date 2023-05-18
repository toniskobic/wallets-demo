namespace Business.Services
{
    using System.Net;
    using System.Net.Mail;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Options;
    using Business.Services.Interfaces;
    using Business.Models;

    public class EmailService : IEmailService
    {
        private readonly EmailSettings _mailSettings;

        public EmailService(IOptions<EmailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public async Task SendEmailAsync(EmailRequest mailRequest)
        {
            MailMessage email = new MailMessage();
            email.From = new MailAddress(_mailSettings.Mail);
            email.To.Add(new MailAddress(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;
            email.Body = mailRequest.Body;
            email.IsBodyHtml = true;

            if (mailRequest.Attachments != null)
            {
                foreach (var attachment in mailRequest.Attachments)
                {
                    email.Attachments.Add(attachment);
                }
            }

            SmtpClient smtpClient = new SmtpClient(_mailSettings.Host, _mailSettings.Port);
            smtpClient.EnableSsl = _mailSettings.Ssl;
            smtpClient.Credentials = new NetworkCredential(_mailSettings.Mail, _mailSettings.Password);
            await smtpClient.SendMailAsync(email);
        }
    }
}
