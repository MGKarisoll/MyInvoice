using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInvoice.Domain.Core
{
    public class PropertyCategory
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public string CategoryName { get; set; }

        public virtual Property Property { get; set; }
    }
}
