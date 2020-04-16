namespace TruckApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropStopsFromLeg : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Legs", "Stop1Id", "dbo.Stops");
            DropForeignKey("dbo.Legs", "Stop2Id", "dbo.Stops");
            DropIndex("dbo.Legs", new[] { "Stop1Id" });
            DropIndex("dbo.Legs", new[] { "Stop2Id" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Legs", "Stop2Id");
            CreateIndex("dbo.Legs", "Stop1Id");
            AddForeignKey("dbo.Legs", "Stop2Id", "dbo.Stops", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Legs", "Stop1Id", "dbo.Stops", "Id", cascadeDelete: true);
        }
    }
}
