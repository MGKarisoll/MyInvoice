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
            context.Properties.AddOrUpdate(x => x.Id, new[] {
                new Property{ Id = 0, Name = "PHONE", ValidationExpression = "+[d+] (d+) d3-d2-d2", StringFormat = "{0}" },
                new Property{ Id = 1, Name = "EMAIL", ValidationExpression = "/@/", StringFormat = "{0}" },
            });
        }
    }
}
