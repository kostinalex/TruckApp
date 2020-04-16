namespace TruckApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConfIdToLeg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Legs", "LoadConfirmationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Legs", "LoadConfirmationId");
            AddForeignKey("dbo.Legs", "LoadConfirmationId", "dbo.LoadConfirmations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Legs", "LoadConfirmationId", "dbo.LoadConfirmations");
            DropIndex("dbo.Legs", new[] { "LoadConfirmationId" });
            DropColumn("dbo.Legs", "LoadConfirmationId");
        }
    }
}
