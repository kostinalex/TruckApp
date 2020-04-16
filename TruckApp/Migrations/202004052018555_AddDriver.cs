namespace TruckApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDriver : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.LoadConfirmations", "DriverId", c => c.Int(nullable: false));
            CreateIndex("dbo.LoadConfirmations", "DriverId");
            AddForeignKey("dbo.LoadConfirmations", "DriverId", "dbo.Drivers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LoadConfirmations", "DriverId", "dbo.Drivers");
            DropIndex("dbo.LoadConfirmations", new[] { "DriverId" });
            DropColumn("dbo.LoadConfirmations", "DriverId");
            DropTable("dbo.Drivers");
        }
    }
}
