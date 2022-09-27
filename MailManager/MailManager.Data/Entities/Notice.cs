using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailManager.Data.Entities.Base;

namespace MailManager.Data.Entities
{
    public class Notice : BaseEntity
    {
        public string Subject { get; set; }
        public string Text { get; set; }
    }
}
