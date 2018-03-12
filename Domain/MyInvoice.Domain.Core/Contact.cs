using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInvoice.Domain.Core
{
    public class Contact
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<ContactProperty> ContactProperties { get; set; }
        public virtual Account Account { get; set; }
    }
}
