namespace TruckApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEquipment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.LoadConfirmations", "EquipmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.LoadConfirmations", "EquipmentId");
            AddForeignKey("dbo.LoadConfirmations", "EquipmentId", "dbo.Equipments", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LoadConfirmations", "EquipmentId", "dbo.Equipments");
            DropIndex("dbo.LoadConfirmations", new[] { "EquipmentId" });
            DropColumn("dbo.LoadConfirmations", "EquipmentId");
            DropTable("dbo.Equipments");
        }
    }
}
