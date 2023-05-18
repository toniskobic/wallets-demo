namespace Business.Models
{
    using System.Net.Mail;

    public class EmailRequest
    {
        public string ToEmail { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public List<Attachment>? Attachments { get; set; }
    }
}
