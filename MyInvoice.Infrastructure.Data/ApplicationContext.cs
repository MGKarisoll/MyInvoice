using System.Configuration;
using System.Data.Entity;
using MyInvoice.Domain.Core;
using MyInvoice.Infrastructure.Data.Schema;
using MyInvoice.Infrastructure.Data.Schema.Interfaces;

namespace MyInvoice.Infrastructure.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base(
            ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactProperty> ContactProperties { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyCategory> PropertyCategories { get; set; }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var schemas = new ITableEntitySchema[]
            {
                new ContactTableSchema(),
                new ContactTableSchema(),
                new PropertyCategoryTableSchema(),
                new PropertyTableSchema(),
                new UserTableSchema()
            };
            foreach (var schema in schemas) schema.Configure(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}