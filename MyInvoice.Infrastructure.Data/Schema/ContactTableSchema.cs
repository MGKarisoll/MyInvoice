using System.Data.Entity;
using MyInvoice.Domain.Core;
using MyInvoice.Domain.Core.Base;
using MyInvoice.Infrastructure.Data.Schema.Base;

namespace MyInvoice.Infrastructure.Data.Schema
{
    public class ContactTableSchema : BaseEntitySchema<Contact>
    {
        public override void Configure(DbModelBuilder builder)
        {
            builder.Entity<Contact>().ToTable("Contacts");
            base.Configure(builder);
        }
    }
}