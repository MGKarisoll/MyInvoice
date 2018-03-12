using Microsoft.AspNet.Identity.EntityFramework;
using MyInvoice.Domain.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInvoice.Infrastructure.Data
{
    public class SeedManager
    {
        private const string SuperAdminId = "2d349776-144c-47bf-bdb4-c6d247ccdf9c";
        public static void Seed(ApplicationContext context)
        {
            context.Roles.AddOrUpdate(x => x.Id, new[] {
                new IdentityRole{ Id = 0.ToString(), Name = "SUPERADMIN" },
                new IdentityRole{ Id = 1.ToString(), Name = "ADMIN" },
                new IdentityRole{ Id = 2.ToString(), Name = "VENDOR" },
                new IdentityRole{ Id = 3.ToString(), Name = "CUSTUMER" },
                new IdentityRole{ Id = 4.ToString(), Name = "GUEST" }
            });
            context.Users.AddOrUpdate(x => x.Id, new[] { new ApplicationUser { Id = SuperAdminId, UserName = "Admin", Email = "job.myasnikov.gennady@gmail.com", EmailConfirmed = true } });
            if (!context.Users.Find(SuperAdminId).Roles.Any(x => x.RoleId == "0")) context.Users.Find(SuperAdminId).Roles.Add(new IdentityUserRole { RoleId = "0", UserId = SuperAdminId });
            context.Accounts.AddOrUpdate(x => x.Id, new[] { new Account { Id = 0, ApplicationUserId = SuperAdminId } });

            context.Properties.AddOrUpdate(x => x.Id, new[] {
                new Property{ Id = 0, Name = "PHONE", ValidationExpression = "+[d+] (d+) d3-d2-d2", StringFormat = "{0}" },
                new Property{ Id = 1, Name = "EMAIL", ValidationExpression = "/@/", StringFormat = "{0}" },
            });
        }
    }
}
