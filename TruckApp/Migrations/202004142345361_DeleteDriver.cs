namespace TruckApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteDriver : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LoadConfirmations", "DriverId", "dbo.Drivers");
            DropIndex("dbo.LoadConfirmations", new[] { "DriverId" });
            DropColumn("dbo.LoadConfirmations", "DriverId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LoadConfirmations", "DriverId", c => c.Int(nullable: false));
            CreateIndex("dbo.LoadConfirmations", "DriverId");
            AddForeignKey("dbo.LoadConfirmations", "DriverId", "dbo.Drivers", "Id", cascadeDelete: true);
        }
    }
}
