using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailManager.Core.Email
{
    public sealed class MailGatewayOptions
    {
        private const int DefaultPort = 587;
        public MailGatewayOptions()
        {
            Port = DefaultPort;
        }
        public string SenderName { get; set; }
        public string SMTPServer { get; set; }
        public int Port { get; set; }
        public string Sender { get; set; }
        public string Password { get; set; }
    }

}
