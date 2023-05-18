namespace Business.Services
{
    using System.Net.Mail;
    using System.Threading.Tasks;
    using Business.Services.Interfaces;
    using Microsoft.Extensions.Options;
    using Business.Models;
    using Business.Static;
    using System.Reflection;

    public class EventService : IEventService
    {
        private static readonly List<Event> Events = new List<Event>
        {
            new Event
            {
                Id = Guid.Empty,
                Name = "Event1"
            },
            new Event
            {
                Id = Guid.NewGuid(),
                Name = "Event3"
            },
            new Event
            {
                Id = Guid.NewGuid(),
                Name = "Event4"
            },
            new Event
            {
                Id = Guid.NewGuid(),
                Name = "Event6"
            }
        };

        private readonly GoogleApplicationCredentials _googleApplicationCredentials;
        private readonly IEmailService _emailSender;
        private readonly IGenericPassService _demoGeneric;

        public EventService(
            IOptions<GoogleApplicationCredentials> googleApplicationCredentials,
            IEmailService emailSender,
            IGenericPassService demoGeneric)
        {
            _googleApplicationCredentials = googleApplicationCredentials.Value;
            _emailSender = emailSender;
            _demoGeneric = demoGeneric;
        }

        public async Task SubscribeAsync(string email)
        {
            var objectId = Guid.NewGuid().ToString();
            _demoGeneric.CreateObject(_googleApplicationCredentials.Issuer, _googleApplicationCredentials.Class, objectId);
            string link = _demoGeneric.CreateJWTNewObjects(_googleApplicationCredentials.Issuer, _googleApplicationCredentials.Class, objectId);

            var buildDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Attachment attachment = new Attachment(@$"{buildDir}\{Constants.GOOGLE_WALLET_BUTTON_PATH}");
            attachment.ContentId = Constants.GOOGLE_WALLET_BUTTON_CONTENT_ID;

            var body = $"<a href=\"{link}\"><img src=\"cid:{attachment.ContentId}\"></a>";

            await _emailSender.SendEmailAsync(new EmailRequest
            {
                ToEmail = email,
                Subject = "Wallet POC",
                Body = body,
                Attachments = new List<Attachment> { attachment }
            });
        }
    }
}
