using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using MyInvoice.Domain.Core;
using MyInvoice.Infrastructure.Data;

namespace MyInvoice.Infrastructure.Business
{
    public class AccountManager : UserManager<ApplicationUser>
    {
        public AccountManager(IUserStore<ApplicationUser> store) : base(store)
        {
        }

        public static AccountManager Create(IdentityFactoryOptions<AccountManager> options,
                                            IOwinContext context)
        {
            ApplicationContext db = context.Get<ApplicationContext>("");
            AccountManager manager = new AccountManager(new UserStore<ApplicationUser>(db));
            return manager;
        }
    }
}
