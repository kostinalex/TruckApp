namespace TruckApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDispatchAndPriorities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dispatches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PriorityDeliveries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PriorityEntries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.LoadConfirmations", "PriorityDeliveryId", c => c.Int(nullable: false));
            AddColumn("dbo.LoadConfirmations", "PriorityEntryId", c => c.Int(nullable: false));
            AddColumn("dbo.LoadConfirmations", "DispatchId", c => c.Int(nullable: false));
            CreateIndex("dbo.LoadConfirmations", "PriorityDeliveryId");
            CreateIndex("dbo.LoadConfirmations", "PriorityEntryId");
            CreateIndex("dbo.LoadConfirmations", "DispatchId");
            AddForeignKey("dbo.LoadConfirmations", "DispatchId", "dbo.Dispatches", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LoadConfirmations", "PriorityDeliveryId", "dbo.PriorityDeliveries", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LoadConfirmations", "PriorityEntryId", "dbo.PriorityEntries", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LoadConfirmations", "PriorityEntryId", "dbo.PriorityEntries");
            DropForeignKey("dbo.LoadConfirmations", "PriorityDeliveryId", "dbo.PriorityDeliveries");
            DropForeignKey("dbo.LoadConfirmations", "DispatchId", "dbo.Dispatches");
            DropIndex("dbo.LoadConfirmations", new[] { "DispatchId" });
            DropIndex("dbo.LoadConfirmations", new[] { "PriorityEntryId" });
            DropIndex("dbo.LoadConfirmations", new[] { "PriorityDeliveryId" });
            DropColumn("dbo.LoadConfirmations", "DispatchId");
            DropColumn("dbo.LoadConfirmations", "PriorityEntryId");
            DropColumn("dbo.LoadConfirmations", "PriorityDeliveryId");
            DropTable("dbo.PriorityEntries");
            DropTable("dbo.PriorityDeliveries");
            DropTable("dbo.Dispatches");
        }
    }
}
