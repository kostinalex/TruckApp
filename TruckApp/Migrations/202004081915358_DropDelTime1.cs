namespace TruckApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropDelTime1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stops", "Date1", c => c.DateTime(nullable: false));
            AddColumn("dbo.Stops", "Date2", c => c.DateTime(nullable: false));
            DropColumn("dbo.Stops", "PuDate1");
            DropColumn("dbo.Stops", "PuDate2");
            DropColumn("dbo.Stops", "PuTime1");
            DropColumn("dbo.Stops", "PuTime2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stops", "PuTime2", c => c.DateTime(nullable: false));
            AddColumn("dbo.Stops", "PuTime1", c => c.DateTime(nullable: false));
            AddColumn("dbo.Stops", "PuDate2", c => c.DateTime(nullable: false));
            AddColumn("dbo.Stops", "PuDate1", c => c.DateTime(nullable: false));
            DropColumn("dbo.Stops", "Date2");
            DropColumn("dbo.Stops", "Date1");
        }
    }
}
