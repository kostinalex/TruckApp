namespace TruckApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStops : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoadConfirmationId = c.Int(nullable: false),
                        OrderNumber = c.Byte(nullable: false),
                        PUStatus = c.Boolean(nullable: false),
                        FacilityName = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LoadConfirmations", t => t.LoadConfirmationId, cascadeDelete: true)
                .Index(t => t.LoadConfirmationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stops", "LoadConfirmationId", "dbo.LoadConfirmations");
            DropIndex("dbo.Stops", new[] { "LoadConfirmationId" });
            DropTable("dbo.Stops");
        }
    }
}
