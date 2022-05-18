using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailManager.Core.Models;

namespace MailManager.Core.Services
{
    public class TemplateService
    {
        public static Message Convert(Message message)
        {
            string template = File.ReadAllText("D:\\Configurations\\template.md");
            string result = String.Format(template, message.Name, message.Subject, message.Body);
            message.Body = result;
            return message;
        }
    }
}
