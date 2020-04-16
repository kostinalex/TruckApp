namespace TruckApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDarkTheme1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "DarkTheme", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "DarkTheme", c => c.Boolean(nullable: false));
        }
    }
}
