using MyInvoice.Domain.Core;
using MyInvoice.Domain.Interfaces.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyInvoice.Domain.Interfaces
{
    public interface IContactRepository: IRepository<Contact>
    {
        Task<IEnumerable<Contact>> GetContactsAsync(int accountId);
        Task<IEnumerable<Contact>> GetContactsAsync(int accountId, string name);
    }
}
