using System.Data.Entity;
using MyInvoice.Domain.Core;
using MyInvoice.Infrastructure.Data.Schema.Base;

namespace MyInvoice.Infrastructure.Data.Schema
{
    public class PropertyCategoryTableSchema : BaseEntitySchema<PropertyCategory>
    {
        public override void Configure(DbModelBuilder builder)
        {
            builder.Entity<PropertyCategory>()
                .ToTable("PropertyCategories");

            base.Configure(builder);
        }
    }
}