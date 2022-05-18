using MailManager.Core.Models;

namespace MailManager.Core.Intarfaces
{
    public interface ISender
    {
        public Task SendAsync(Message message);
    }
}