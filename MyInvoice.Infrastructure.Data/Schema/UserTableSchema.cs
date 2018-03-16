using System.Data.Entity;
using MyInvoice.Domain.Core;
using MyInvoice.Infrastructure.Data.Schema.Base;

namespace MyInvoice.Infrastructure.Data.Schema
{
    public class UserTableSchema : BaseEntitySchema<User>
    {
        public override void Configure(DbModelBuilder builder)
        {
            builder.Entity<User>().ToTable("Users");
            base.Configure(builder);
        }
    }
}