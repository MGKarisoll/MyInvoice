using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyInvoice.Domain.Core.Base;

namespace MyInvoice.Domain.Core
{
    public class PropertyCategory : BaseEntity
    {
        public int PropertyId { get; set; }
        public string CategoryName { get; set; }

        public virtual Property Property { get; set; }
    }
}
