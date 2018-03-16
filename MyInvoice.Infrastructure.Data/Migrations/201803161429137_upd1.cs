namespace MyInvoice.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upd1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Accounts", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Contacts", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ContactProperties", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.ContactProperties", "PropertyId", "dbo.Properties");
            DropForeignKey("dbo.PropertyCategories", "PropertyId", "dbo.Properties");
            DropIndex("dbo.Accounts", new[] { "ApplicationUserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.Contacts", new[] { "AccountId" });
            DropIndex("dbo.ContactProperties", new[] { "ContactId" });
            DropIndex("dbo.ContactProperties", new[] { "PropertyId" });
            DropIndex("dbo.PropertyCategories", new[] { "PropertyId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropPrimaryKey("dbo.Contacts");
            DropPrimaryKey("dbo.ContactProperties");
            DropPrimaryKey("dbo.Properties");
            DropPrimaryKey("dbo.PropertyCategories");
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Contacts", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Contacts", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Contacts", "User_Id", c => c.Long());
            AddColumn("dbo.ContactProperties", "RowVersion", c => c.Binary());
            AddColumn("dbo.ContactProperties", "Contact_Id", c => c.Long());
            AddColumn("dbo.ContactProperties", "Property_Id", c => c.Long());
            AddColumn("dbo.Properties", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.PropertyCategories", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.PropertyCategories", "Property_Id", c => c.Long());
            AlterColumn("dbo.Contacts", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.ContactProperties", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Properties", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.PropertyCategories", "Id", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.Contacts", "Id");
            AddPrimaryKey("dbo.ContactProperties", "Id");
            AddPrimaryKey("dbo.Properties", "Id");
            AddPrimaryKey("dbo.PropertyCategories", "Id");
            CreateIndex("dbo.ContactProperties", "Contact_Id");
            CreateIndex("dbo.ContactProperties", "Property_Id");
            CreateIndex("dbo.Contacts", "User_Id");
            CreateIndex("dbo.PropertyCategories", "Property_Id");
            AddForeignKey("dbo.Contacts", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.ContactProperties", "Contact_Id", "dbo.Contacts", "Id");
            AddForeignKey("dbo.ContactProperties", "Property_Id", "dbo.Properties", "Id");
            AddForeignKey("dbo.PropertyCategories", "Property_Id", "dbo.Properties", "Id");
            DropColumn("dbo.Contacts", "AccountId");
            DropTable("dbo.Accounts");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId });
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId });
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Contacts", "AccountId", c => c.Int(nullable: false));
            DropForeignKey("dbo.PropertyCategories", "Property_Id", "dbo.Properties");
            DropForeignKey("dbo.ContactProperties", "Property_Id", "dbo.Properties");
            DropForeignKey("dbo.ContactProperties", "Contact_Id", "dbo.Contacts");
            DropForeignKey("dbo.Contacts", "User_Id", "dbo.Users");
            DropIndex("dbo.PropertyCategories", new[] { "Property_Id" });
            DropIndex("dbo.Contacts", new[] { "User_Id" });
            DropIndex("dbo.ContactProperties", new[] { "Property_Id" });
            DropIndex("dbo.ContactProperties", new[] { "Contact_Id" });
            DropPrimaryKey("dbo.PropertyCategories");
            DropPrimaryKey("dbo.Properties");
            DropPrimaryKey("dbo.ContactProperties");
            DropPrimaryKey("dbo.Contacts");
            AlterColumn("dbo.PropertyCategories", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Properties", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.ContactProperties", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Contacts", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.PropertyCategories", "Property_Id");
            DropColumn("dbo.PropertyCategories", "RowVersion");
            DropColumn("dbo.Properties", "RowVersion");
            DropColumn("dbo.ContactProperties", "Property_Id");
            DropColumn("dbo.ContactProperties", "Contact_Id");
            DropColumn("dbo.ContactProperties", "RowVersion");
            DropColumn("dbo.Contacts", "User_Id");
            DropColumn("dbo.Contacts", "RowVersion");
            DropColumn("dbo.Contacts", "UserId");
            DropTable("dbo.Users");
            AddPrimaryKey("dbo.PropertyCategories", "Id");
            AddPrimaryKey("dbo.Properties", "Id");
            AddPrimaryKey("dbo.ContactProperties", "Id");
            AddPrimaryKey("dbo.Contacts", "Id");
            CreateIndex("dbo.AspNetRoles", "Name", unique: true, name: "RoleNameIndex");
            CreateIndex("dbo.PropertyCategories", "PropertyId");
            CreateIndex("dbo.ContactProperties", "PropertyId");
            CreateIndex("dbo.ContactProperties", "ContactId");
            CreateIndex("dbo.Contacts", "AccountId");
            CreateIndex("dbo.AspNetUserRoles", "RoleId");
            CreateIndex("dbo.AspNetUserRoles", "UserId");
            CreateIndex("dbo.AspNetUserLogins", "UserId");
            CreateIndex("dbo.AspNetUserClaims", "UserId");
            CreateIndex("dbo.AspNetUsers", "UserName", unique: true, name: "UserNameIndex");
            CreateIndex("dbo.Accounts", "ApplicationUserId");
            AddForeignKey("dbo.PropertyCategories", "PropertyId", "dbo.Properties", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ContactProperties", "PropertyId", "dbo.Properties", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ContactProperties", "ContactId", "dbo.Contacts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Contacts", "AccountId", "dbo.Accounts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Accounts", "ApplicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
