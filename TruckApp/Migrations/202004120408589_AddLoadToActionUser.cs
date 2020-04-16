namespace TruckApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLoadToActionUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserActions", "LoadConfirmationId", c => c.Int(nullable: true));
            CreateIndex("dbo.UserActions", "LoadConfirmationId");
            AddForeignKey("dbo.UserActions", "LoadConfirmationId", "dbo.LoadConfirmations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserActions", "LoadConfirmationId", "dbo.LoadConfirmations");
            DropIndex("dbo.UserActions", new[] { "LoadConfirmationId" });
            DropColumn("dbo.UserActions", "LoadConfirmationId");
        }
    }
}
