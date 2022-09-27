using MailManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MailManager.Data.SQLServer
{
    public class SQLServerDataBaseNotices : SQLServerDataBase<Notice>
    {
        public SQLServerDataBaseNotices(MailContext context) : base(context) { }

        public override async Task<List<Notice>> GetAllAsync()
        {
            return await _context.Messages!.ToListAsync<Notice>();
        }

        public override async Task<Notice> GetLastElement()
        {
            return await _context.Messages!
                .Where(Message => Message.Id == _context.Messages!.Max(cl => cl.Id))
                .FirstOrDefaultAsync();
        }
    }
}
