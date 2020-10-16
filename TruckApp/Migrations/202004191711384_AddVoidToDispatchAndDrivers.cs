namespace TruckApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVoidToDispatchAndDrivers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dispatches", "Void", c => c.Boolean());
            AddColumn("dbo.Drivers", "Void", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Drivers", "Void");
            DropColumn("dbo.Dispatches", "Void");
        }
    }
}
