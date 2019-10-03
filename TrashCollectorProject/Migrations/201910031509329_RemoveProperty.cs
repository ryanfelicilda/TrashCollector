namespace TrashCollectorProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "PickupDay", c => c.String());
            DropColumn("dbo.Customers", "oneTimePickupDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "oneTimePickupDate", c => c.String());
            DropColumn("dbo.Customers", "PickupDay");
        }
    }
}
