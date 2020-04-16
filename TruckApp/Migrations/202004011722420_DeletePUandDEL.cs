namespace TruckApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletePUandDEL : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LoadConfirmations", "DeliveryId", "dbo.Deliveries");
            DropForeignKey("dbo.LoadConfirmations", "PickUpId", "dbo.PickUps");
            DropIndex("dbo.LoadConfirmations", new[] { "PickUpId" });
            DropIndex("dbo.LoadConfirmations", new[] { "DeliveryId" });
            DropColumn("dbo.LoadConfirmations", "PickUpId");
            DropColumn("dbo.LoadConfirmations", "DeliveryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LoadConfirmations", "DeliveryId", c => c.Int(nullable: false));
            AddColumn("dbo.LoadConfirmations", "PickUpId", c => c.Int(nullable: false));
            CreateIndex("dbo.LoadConfirmations", "DeliveryId");
            CreateIndex("dbo.LoadConfirmations", "PickUpId");
            AddForeignKey("dbo.LoadConfirmations", "PickUpId", "dbo.PickUps", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LoadConfirmations", "DeliveryId", "dbo.Deliveries", "Id", cascadeDelete: true);
        }
    }
}
