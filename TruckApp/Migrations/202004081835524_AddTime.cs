namespace TruckApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stops", "PuDate1", c => c.DateTime(nullable: false));
            AddColumn("dbo.Stops", "PuDate2", c => c.DateTime(nullable: false));
            AddColumn("dbo.Stops", "PuTime1", c => c.DateTime(nullable: false));
            AddColumn("dbo.Stops", "PuTime2", c => c.DateTime(nullable: false));
            AddColumn("dbo.Stops", "DelDate1", c => c.DateTime(nullable: false));
            AddColumn("dbo.Stops", "DelDate2", c => c.DateTime(nullable: false));
            AddColumn("dbo.Stops", "DelTime1", c => c.DateTime(nullable: false));
            AddColumn("dbo.Stops", "DelTime2", c => c.DateTime(nullable: false));
            DropColumn("dbo.LoadConfirmations", "PickUpFacilityName");
            DropColumn("dbo.LoadConfirmations", "PickUpAddress");
            DropColumn("dbo.LoadConfirmations", "PickUpCity");
            DropColumn("dbo.LoadConfirmations", "PickUpState");
            DropColumn("dbo.LoadConfirmations", "PickUpCountry");
            DropColumn("dbo.LoadConfirmations", "PickUpZipcode");
            DropColumn("dbo.LoadConfirmations", "DeliveryFacilityName");
            DropColumn("dbo.LoadConfirmations", "DeliveryAddress");
            DropColumn("dbo.LoadConfirmations", "DeliveryCity");
            DropColumn("dbo.LoadConfirmations", "DeliveryState");
            DropColumn("dbo.LoadConfirmations", "DeliveryCountry");
            DropColumn("dbo.LoadConfirmations", "DeliveryZipcode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LoadConfirmations", "DeliveryZipcode", c => c.String());
            AddColumn("dbo.LoadConfirmations", "DeliveryCountry", c => c.String());
            AddColumn("dbo.LoadConfirmations", "DeliveryState", c => c.String());
            AddColumn("dbo.LoadConfirmations", "DeliveryCity", c => c.String());
            AddColumn("dbo.LoadConfirmations", "DeliveryAddress", c => c.String());
            AddColumn("dbo.LoadConfirmations", "DeliveryFacilityName", c => c.String());
            AddColumn("dbo.LoadConfirmations", "PickUpZipcode", c => c.String());
            AddColumn("dbo.LoadConfirmations", "PickUpCountry", c => c.String());
            AddColumn("dbo.LoadConfirmations", "PickUpState", c => c.String());
            AddColumn("dbo.LoadConfirmations", "PickUpCity", c => c.String());
            AddColumn("dbo.LoadConfirmations", "PickUpAddress", c => c.String());
            AddColumn("dbo.LoadConfirmations", "PickUpFacilityName", c => c.String());
            DropColumn("dbo.Stops", "DelTime2");
            DropColumn("dbo.Stops", "DelTime1");
            DropColumn("dbo.Stops", "DelDate2");
            DropColumn("dbo.Stops", "DelDate1");
            DropColumn("dbo.Stops", "PuTime2");
            DropColumn("dbo.Stops", "PuTime1");
            DropColumn("dbo.Stops", "PuDate2");
            DropColumn("dbo.Stops", "PuDate1");
        }
    }
}
