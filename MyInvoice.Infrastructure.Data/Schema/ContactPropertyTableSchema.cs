using System.Data.Entity;
using MyInvoice.Domain.Core;
using MyInvoice.Infrastructure.Data.Schema.Base;

namespace MyInvoice.Infrastructure.Data.Schema
{
    public class ContactPropertyTableSchema : BaseEntitySchema<ContactProperty>
    {
        public override void Configure(DbModelBuilder builder)
        {
            builder.Entity<ContactProperty>()
                .ToTable("ContactProperties");

            base.Configure(builder);
        }
    }
}