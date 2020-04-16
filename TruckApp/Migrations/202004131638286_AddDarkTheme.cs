namespace TruckApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDarkTheme : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DarkTheme", c => c.Boolean(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DarkTheme");
        }
    }
}
