using Quartz;
using MailManager.Core.Intarfaces;
using MailManager.Core.Models;
using MailManager.Data.Entities;
using MailManager.Data.Interfaces;
using MailManager.Data.SQLServer;
using MailManager.Core.Services;

namespace MailManager.WebApi.Jobs
{
    public class QuartzSender : IJob
    {
        private readonly ISender _sender;
        private readonly SQLServer _sqlserver;

        public QuartzSender(ISender sender, SQLServer sqlserver)
        {
            _sender = sender;
            _sqlserver = sqlserver;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            var clients = await _sqlserver.Clients.GetAllAsync();
            var notice = await _sqlserver.Notices.GetLastElement();
            foreach (var client in clients)
            {
                var message = new Message
                {
                    Subject = notice.Subject,
                    Body = notice.Text,
                    To = client.Mail,
                    Name = client.Name
                };
                var template = TemplateService.Convert(message);
                await _sender.SendAsync(template);
            }

        }
    }
}
