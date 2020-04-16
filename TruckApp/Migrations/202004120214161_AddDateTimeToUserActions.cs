namespace TruckApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateTimeToUserActions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserActions", "DateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserActions", "DateTime");
        }
    }
}
