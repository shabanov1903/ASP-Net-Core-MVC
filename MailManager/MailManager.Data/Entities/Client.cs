using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailManager.Data.Entities.Base;

namespace MailManager.Data.Entities
{
    public class Client : BaseEntity
    {
        public string Name { get; set; }
        public string Mail { get; set; }
    }
}
