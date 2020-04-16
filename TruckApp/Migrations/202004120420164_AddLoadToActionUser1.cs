namespace TruckApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLoadToActionUser1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserActions", "LoadConfirmationId", "dbo.LoadConfirmations");
            DropIndex("dbo.UserActions", new[] { "LoadConfirmationId" });
            AlterColumn("dbo.UserActions", "LoadConfirmationId", c => c.Int());
            CreateIndex("dbo.UserActions", "LoadConfirmationId");
            AddForeignKey("dbo.UserActions", "LoadConfirmationId", "dbo.LoadConfirmations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserActions", "LoadConfirmationId", "dbo.LoadConfirmations");
            DropIndex("dbo.UserActions", new[] { "LoadConfirmationId" });
            AlterColumn("dbo.UserActions", "LoadConfirmationId", c => c.Int(nullable: false));
            CreateIndex("dbo.UserActions", "LoadConfirmationId");
            AddForeignKey("dbo.UserActions", "LoadConfirmationId", "dbo.LoadConfirmations", "Id", cascadeDelete: true);
        }
    }
}
