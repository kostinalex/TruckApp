namespace TruckApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addHazMatReference : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LoadConfirmations", "HazMatStatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.LoadConfirmations", "HazMatStatusId");
            AddForeignKey("dbo.LoadConfirmations", "HazMatStatusId", "dbo.HazMatStatus", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LoadConfirmations", "HazMatStatusId", "dbo.HazMatStatus");
            DropIndex("dbo.LoadConfirmations", new[] { "HazMatStatusId" });
            DropColumn("dbo.LoadConfirmations", "HazMatStatusId");
        }
    }
}
