using Microsoft.AspNet.Identity.EntityFramework;
using MyInvoice.Domain.Core;
using System.Data.Entity;

namespace MyInvoice.Infrastructure.Data
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactProperty> ContactProperties { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyCategory> PropertyCategories { get; set; }

        public ApplicationContext() : base("DbConnectionString") { }
        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasKey(x => x.Id)
                                          .HasRequired(x => x.ApplicationUser);

            modelBuilder.Entity<Contact>().HasKey(x => x.Id)
                                          .HasRequired(c=>c.Account)
                                          .WithMany(a=>a.Contacts)
                                          .HasForeignKey(c=>c.AccountId);

            modelBuilder.Entity<ContactProperty>().HasKey(x => x.Id)
                                                  .HasRequired(cp=>cp.Contact)
                                                  .WithMany(c=>c.ContactProperties)
                                                  .HasForeignKey(cp=>cp.ContactId);
            modelBuilder.Entity<ContactProperty>().HasRequired(cp => cp.Property)
                                                  .WithMany(p => p.ContactProperties)
                                                  .HasForeignKey(x => x.PropertyId);

            modelBuilder.Entity<Property>().HasKey(x => x.Id);

            modelBuilder.Entity<PropertyCategory>().HasKey(x => x.Id)
                                                   .HasRequired(pc=>pc.Property)
                                                   .WithMany(p=>p.PropertyCategories)
                                                   .HasForeignKey(pc => pc.PropertyId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
