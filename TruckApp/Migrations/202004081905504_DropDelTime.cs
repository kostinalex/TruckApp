namespace TruckApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropDelTime : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Stops", "DelDate1");
            DropColumn("dbo.Stops", "DelDate2");
            DropColumn("dbo.Stops", "DelTime1");
            DropColumn("dbo.Stops", "DelTime2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stops", "DelTime2", c => c.DateTime(nullable: false));
            AddColumn("dbo.Stops", "DelTime1", c => c.DateTime(nullable: false));
            AddColumn("dbo.Stops", "DelDate2", c => c.DateTime(nullable: false));
            AddColumn("dbo.Stops", "DelDate1", c => c.DateTime(nullable: false));
        }
    }
}
