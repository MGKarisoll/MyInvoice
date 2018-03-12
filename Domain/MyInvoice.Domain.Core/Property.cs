using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInvoice.Domain.Core
{
    public class Property
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ValidationExpression { get; set; }
        public string StringFormat { get; set; }

        public virtual ICollection<PropertyCategory> PropertyCategories { get; set; }
        public virtual ICollection<ContactProperty> ContactProperties { get; set; }
    }
}
