using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailManager.Data.Interfaces
{
    public interface IRepository<T>
    {
        public Task AddAsync(T entity);
        public Task<List<T>> GetAllAsync();
        public Task<T> GetLastElement();
    }
}
