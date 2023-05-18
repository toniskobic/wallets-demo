namespace Business.Services.Interfaces
{
    using Business.Models;

    public interface IEmailService
    {
        Task SendEmailAsync(EmailRequest mailRequest);
    }
}
