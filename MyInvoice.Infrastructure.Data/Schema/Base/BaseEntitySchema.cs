using System.Data.Entity;
using MyInvoice.Domain.Core.Base;
using MyInvoice.Infrastructure.Data.Schema.Interfaces;

namespace MyInvoice.Infrastructure.Data.Schema.Base
{
    public abstract class BaseEntitySchema<T> : ITableEntitySchema where T : BaseEntity
    {
        public virtual void Configure(DbModelBuilder builder)
        {
            builder.Entity<T>()
                .HasKey(x => x.Id);
            builder.Entity<T>()
                .Property(x => x.RowVersion)
                .IsRowVersion();
        }
    }
}