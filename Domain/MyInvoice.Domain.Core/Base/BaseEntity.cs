using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInvoice.Domain.Core.Base
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
