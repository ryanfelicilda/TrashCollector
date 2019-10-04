namespace TrashCollectorProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDataTypeForBalance : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "balance", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "balance", c => c.Int(nullable: false));
        }
    }
}
