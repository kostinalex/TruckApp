namespace TruckApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteDateTime : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.LoadConfirmations", "PickUpTime1");
            DropColumn("dbo.LoadConfirmations", "PickUpTime2");
            DropColumn("dbo.LoadConfirmations", "DeliveryTime1");
            DropColumn("dbo.LoadConfirmations", "DeliveryTime2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LoadConfirmations", "DeliveryTime2", c => c.DateTime(nullable: false));
            AddColumn("dbo.LoadConfirmations", "DeliveryTime1", c => c.DateTime(nullable: false));
            AddColumn("dbo.LoadConfirmations", "PickUpTime2", c => c.DateTime(nullable: false));
            AddColumn("dbo.LoadConfirmations", "PickUpTime1", c => c.DateTime(nullable: false));
        }
    }
}
