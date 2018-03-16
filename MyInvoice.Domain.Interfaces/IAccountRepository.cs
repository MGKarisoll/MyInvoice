using MyInvoice.Domain.Core;
using MyInvoice.Domain.Interfaces.Base;
using System.Threading.Tasks;

namespace MyInvoice.Domain.Interfaces
{
    public interface IAccountRepository : IRepository<User>
    {
        Task<User> GetItemAsync(string login, string password);
    }
}
