using MailManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailManager.Data
{
    public class MailContext : DbContext
    {
        public MailContext(DbContextOptions<MailContext> options) : base(options)
        { 
            Database.EnsureCreated();
        }

        public DbSet<Client>? Clients { get; set; }
        public DbSet<Notice>? Messages { get; set; }
    }
}
