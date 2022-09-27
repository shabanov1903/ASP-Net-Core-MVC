using System;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailManager.Core.Models;
using MailManager.Core.Intarfaces;
using MimeKit;


namespace MailManager.Core.Email
{
    public class MessageGateway : IDisposable, ISender
    {
        private readonly MailGatewayOptions _options;
        private readonly SmtpClient _client = new();
        public MessageGateway(MailGatewayOptions options)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }
            _options = options;
            _client.Connect(options.SMTPServer, options.Port);
            _client.Authenticate(options.Sender, options.Password);
        }
        public async Task SendAsync(Message message)
        {
            MimeMessage emailMessage = new();
            emailMessage.From.Add(new MailboxAddress(_options.SenderName, _options.Sender));
            emailMessage.To.Add(new MailboxAddress(message.Name, message.To));
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = message.Body
            };
            await _client.SendAsync(emailMessage);
        }
        public void Dispose()
        {
            _client.Disconnect(true);
            _client.Dispose();
        }
    }
}
