using MailManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MailManager.Data.SQLServer
{
    public class SQLServerDataBaseClients : SQLServerDataBase<Client>
    {
        public SQLServerDataBaseClients(MailContext context) : base(context) { }

        public override async Task<List<Client>> GetAllAsync()
        {
            return await _context.Clients!.ToListAsync<Client>();
        }

        public override async Task<Client> GetLastElement()
        {
            return await _context.Clients!
                .Where(client => client.Id == _context.Clients!.Max(cl => cl.Id))
                .FirstOrDefaultAsync();
        }
    }
}
