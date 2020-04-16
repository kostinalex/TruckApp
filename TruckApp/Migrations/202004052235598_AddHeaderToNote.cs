namespace TruckApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHeaderToNote : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notes", "Header", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notes", "Header");
        }
    }
}
