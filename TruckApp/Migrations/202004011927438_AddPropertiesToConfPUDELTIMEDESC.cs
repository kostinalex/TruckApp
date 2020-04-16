namespace TruckApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertiesToConfPUDELTIMEDESC : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LoadConfirmations", "PickUpFacilityName", c => c.String(nullable: false));
            AddColumn("dbo.LoadConfirmations", "PickUpAddress", c => c.String(nullable: false));
            AddColumn("dbo.LoadConfirmations", "PickUpCity", c => c.String(nullable: false));
            AddColumn("dbo.LoadConfirmations", "PickUpState", c => c.String(nullable: false));
            AddColumn("dbo.LoadConfirmations", "PickUpCountry", c => c.String(nullable: false));
            AddColumn("dbo.LoadConfirmations", "DeliveryFacilityName", c => c.String(nullable: false));
            AddColumn("dbo.LoadConfirmations", "DeliveryAddress", c => c.String(nullable: false));
            AddColumn("dbo.LoadConfirmations", "DeliveryCity", c => c.String(nullable: false));
            AddColumn("dbo.LoadConfirmations", "DeliveryState", c => c.String(nullable: false));
            AddColumn("dbo.LoadConfirmations", "DeliveryCountry", c => c.String(nullable: false));
            AddColumn("dbo.LoadConfirmations", "FreightDescription", c => c.String(nullable: false));
            AddColumn("dbo.LoadConfirmations", "Weight", c => c.Int(nullable: false));
            AddColumn("dbo.LoadConfirmations", "NumberOfPallets", c => c.Byte(nullable: false));
            AddColumn("dbo.LoadConfirmations", "PickUpTime1", c => c.DateTime(nullable: false));
            AddColumn("dbo.LoadConfirmations", "PickUpTime2", c => c.DateTime(nullable: false));
            AddColumn("dbo.LoadConfirmations", "DeliveryTime1", c => c.DateTime(nullable: false));
            AddColumn("dbo.LoadConfirmations", "DeliveryTime2", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LoadConfirmations", "DeliveryTime2");
            DropColumn("dbo.LoadConfirmations", "DeliveryTime1");
            DropColumn("dbo.LoadConfirmations", "PickUpTime2");
            DropColumn("dbo.LoadConfirmations", "PickUpTime1");
            DropColumn("dbo.LoadConfirmations", "NumberOfPallets");
            DropColumn("dbo.LoadConfirmations", "Weight");
            DropColumn("dbo.LoadConfirmations", "FreightDescription");
            DropColumn("dbo.LoadConfirmations", "DeliveryCountry");
            DropColumn("dbo.LoadConfirmations", "DeliveryState");
            DropColumn("dbo.LoadConfirmations", "DeliveryCity");
            DropColumn("dbo.LoadConfirmations", "DeliveryAddress");
            DropColumn("dbo.LoadConfirmations", "DeliveryFacilityName");
            DropColumn("dbo.LoadConfirmations", "PickUpCountry");
            DropColumn("dbo.LoadConfirmations", "PickUpState");
            DropColumn("dbo.LoadConfirmations", "PickUpCity");
            DropColumn("dbo.LoadConfirmations", "PickUpAddress");
            DropColumn("dbo.LoadConfirmations", "PickUpFacilityName");
        }
    }
}
