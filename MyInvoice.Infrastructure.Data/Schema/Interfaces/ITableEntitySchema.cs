using System.Data.Entity;
using MyInvoice.Domain.Core.Base;

namespace MyInvoice.Infrastructure.Data.Schema.Interfaces
{
    public interface ITableEntitySchema
    {
        void Configure(DbModelBuilder builder);
    }
}