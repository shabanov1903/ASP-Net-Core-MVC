using MailManager.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MailManager.Data.SQLServer
{
    public abstract class SQLServerDataBase<T> : IRepository<T> where T : class
    {
        protected readonly MailContext _context;

        public SQLServerDataBase(MailContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public abstract Task<List<T>> GetAllAsync();
        public abstract Task<T> GetLastElement();
    }
}
