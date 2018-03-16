using System.Data.Entity;
using MyInvoice.Domain.Core;
using MyInvoice.Infrastructure.Data.Schema.Base;

namespace MyInvoice.Infrastructure.Data.Schema
{
    public class PropertyTableSchema : BaseEntitySchema<Property>
    {
        public override void Configure(DbModelBuilder builder)
        {
            builder.Entity<Property>()
                .ToTable("Properties");

            base.Configure(builder);
        }
    }
}