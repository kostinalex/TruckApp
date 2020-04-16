namespace TruckApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStopsAgain : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Legs", "Stop1Id");
            CreateIndex("dbo.Legs", "Stop2Id");
            AddForeignKey("dbo.Legs", "Stop1Id", "dbo.Stops", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Legs", "Stop2Id", "dbo.Stops", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Legs", "Stop2Id", "dbo.Stops");
            DropForeignKey("dbo.Legs", "Stop1Id", "dbo.Stops");
            DropIndex("dbo.Legs", new[] { "Stop2Id" });
            DropIndex("dbo.Legs", new[] { "Stop1Id" });
        }
    }
}
