namespace TruckApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLegs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Legs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Stop1Id = c.Int(nullable: false),
                        Stop2Id = c.Int(nullable: false),
                        DriverId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drivers", t => t.DriverId, cascadeDelete: true)
                .ForeignKey("dbo.Stops", t => t.Stop1Id)
                .ForeignKey("dbo.Stops", t => t.Stop2Id)
                .Index(t => t.Stop1Id)
                .Index(t => t.Stop2Id)
                .Index(t => t.DriverId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Legs", "Stop2Id", "dbo.Stops");
            DropForeignKey("dbo.Legs", "Stop1Id", "dbo.Stops");
            DropForeignKey("dbo.Legs", "DriverId", "dbo.Drivers");
            DropIndex("dbo.Legs", new[] { "DriverId" });
            DropIndex("dbo.Legs", new[] { "Stop2Id" });
            DropIndex("dbo.Legs", new[] { "Stop1Id" });
            DropTable("dbo.Legs");
        }
    }
}
