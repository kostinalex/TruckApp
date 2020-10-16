namespace TruckApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNullableDispatchId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LoadConfirmations", "DispatchId", "dbo.Dispatches");
            DropIndex("dbo.LoadConfirmations", new[] { "DispatchId" });
            AlterColumn("dbo.LoadConfirmations", "DispatchId", c => c.Int());
            CreateIndex("dbo.LoadConfirmations", "DispatchId");
            AddForeignKey("dbo.LoadConfirmations", "DispatchId", "dbo.Dispatches", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LoadConfirmations", "DispatchId", "dbo.Dispatches");
            DropIndex("dbo.LoadConfirmations", new[] { "DispatchId" });
            AlterColumn("dbo.LoadConfirmations", "DispatchId", c => c.Int(nullable: false));
            CreateIndex("dbo.LoadConfirmations", "DispatchId");
            AddForeignKey("dbo.LoadConfirmations", "DispatchId", "dbo.Dispatches", "Id", cascadeDelete: true);
        }
    }
}
