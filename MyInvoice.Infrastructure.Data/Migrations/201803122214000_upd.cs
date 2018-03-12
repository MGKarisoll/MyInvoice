namespace MyInvoice.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upd : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.ContactProperties", "PropertyId");
            AddForeignKey("dbo.ContactProperties", "PropertyId", "dbo.Properties", "Id", cascadeDelete: true);
            DropColumn("dbo.Properties", "Value");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Properties", "Value", c => c.String());
            DropForeignKey("dbo.ContactProperties", "PropertyId", "dbo.Properties");
            DropIndex("dbo.ContactProperties", new[] { "PropertyId" });
        }
    }
}
