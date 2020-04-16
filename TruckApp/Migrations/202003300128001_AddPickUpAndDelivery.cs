namespace TruckApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPickUpAndDelivery : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Deliveries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        Time1 = c.DateTime(nullable: false),
                        Time2 = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PickUps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        Time1 = c.DateTime(nullable: false),
                        Time2 = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.LoadConfirmations", "PickUpId", c => c.Int(nullable: false));
            AddColumn("dbo.LoadConfirmations", "DeliveryId", c => c.Int(nullable: false));
            CreateIndex("dbo.LoadConfirmations", "PickUpId");
            CreateIndex("dbo.LoadConfirmations", "DeliveryId");
            AddForeignKey("dbo.LoadConfirmations", "DeliveryId", "dbo.Deliveries", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LoadConfirmations", "PickUpId", "dbo.PickUps", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LoadConfirmations", "PickUpId", "dbo.PickUps");
            DropForeignKey("dbo.LoadConfirmations", "DeliveryId", "dbo.Deliveries");
            DropIndex("dbo.LoadConfirmations", new[] { "DeliveryId" });
            DropIndex("dbo.LoadConfirmations", new[] { "PickUpId" });
            DropColumn("dbo.LoadConfirmations", "DeliveryId");
            DropColumn("dbo.LoadConfirmations", "PickUpId");
            DropTable("dbo.PickUps");
            DropTable("dbo.Deliveries");
        }
    }
}
