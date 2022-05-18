using MailManager.Data.Entities;
using MailManager.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailManager.Data.SQLServer
{
    public class SQLServer
    {
        public readonly IRepository<Client> Clients;
        public readonly IRepository<Notice> Notices;

        public SQLServer(IRepository<Client> Clients, IRepository<Notice> Notices)
        {
            this.Clients = Clients;
            this.Notices = Notices;
        }
    }
}
