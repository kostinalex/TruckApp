namespace TruckApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DelStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stops", "DelStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stops", "DelStatus");
        }
    }
}
