using System.Collections.Generic;

namespace MyInvoice.Domain.Core {
    public class Account {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
