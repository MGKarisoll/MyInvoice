using System.Collections.Generic;
using MyInvoice.Domain.Core.Base;

namespace MyInvoice.Domain.Core {
    public class User: BaseEntity {
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
