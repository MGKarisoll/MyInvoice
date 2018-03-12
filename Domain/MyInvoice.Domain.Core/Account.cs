using System.Collections.Generic;

namespace MyInvoice.Domain.Core {
    public class Account {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
