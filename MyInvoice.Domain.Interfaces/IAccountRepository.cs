using MyInvoice.Domain.Core;
using MyInvoice.Domain.Interfaces.Base;
using System.Threading.Tasks;

namespace MyInvoice.Domain.Interfaces
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<Account> GetItemAsync(string login, string password);
    }
}
