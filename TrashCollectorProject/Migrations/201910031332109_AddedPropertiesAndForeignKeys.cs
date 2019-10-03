namespace TrashCollectorProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPropertiesAndForeignKeys : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "extraPickupDate", c => c.String());
            AddColumn("dbo.Customers", "oneTimePickupDate", c => c.String());
            AddColumn("dbo.Customers", "suspendPickupDate", c => c.String());
            AddColumn("dbo.Customers", "ApplicationId", c => c.String(maxLength: 128));
            AddColumn("dbo.Employees", "ApplicationId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Customers", "zipCode", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "ApplicationId");
            CreateIndex("dbo.Employees", "ApplicationId");
            AddForeignKey("dbo.Customers", "ApplicationId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Employees", "ApplicationId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "ApplicationId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Customers", "ApplicationId", "dbo.AspNetUsers");
            DropIndex("dbo.Employees", new[] { "ApplicationId" });
            DropIndex("dbo.Customers", new[] { "ApplicationId" });
            AlterColumn("dbo.Customers", "zipCode", c => c.String());
            DropColumn("dbo.Employees", "ApplicationId");
            DropColumn("dbo.Customers", "ApplicationId");
            DropColumn("dbo.Customers", "suspendPickupDate");
            DropColumn("dbo.Customers", "oneTimePickupDate");
            DropColumn("dbo.Customers", "extraPickupDate");
        }
    }
}
