using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInvoice.Domain.Interfaces.Base
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetItemsAsync();
        Task<T> GetItemAsync(int id);
        Task<T> CreateItemAsync(T Item);
        Task<T> UpdateItemAsync(T item);
        Task DeleteItemAsync(T item);
    }
}
