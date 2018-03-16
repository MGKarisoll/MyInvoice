using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyInvoice.Domain.Core.Base;

namespace MyInvoice.Domain.Core
{
    public class Contact : BaseEntity
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<ContactProperty> ContactProperties { get; set; }
        public virtual User User { get; set; }
    }
}
