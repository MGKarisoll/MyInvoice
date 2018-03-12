using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInvoice.Domain.Core
{
    public class ContactProperty
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public int PropertyId { get; set; }
        public string Value { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual Property Property { get; set; }
    }
}
