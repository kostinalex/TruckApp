namespace TruckApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeRequiredStatusForLoadConfirmationProperties : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LoadConfirmations", "PickUpFacilityName", c => c.String());
            AlterColumn("dbo.LoadConfirmations", "PickUpAddress", c => c.String());
            AlterColumn("dbo.LoadConfirmations", "PickUpCity", c => c.String());
            AlterColumn("dbo.LoadConfirmations", "PickUpState", c => c.String());
            AlterColumn("dbo.LoadConfirmations", "PickUpCountry", c => c.String());
            AlterColumn("dbo.LoadConfirmations", "DeliveryFacilityName", c => c.String());
            AlterColumn("dbo.LoadConfirmations", "DeliveryAddress", c => c.String());
            AlterColumn("dbo.LoadConfirmations", "DeliveryCity", c => c.String());
            AlterColumn("dbo.LoadConfirmations", "DeliveryState", c => c.String());
            AlterColumn("dbo.LoadConfirmations", "DeliveryCountry", c => c.String());
            AlterColumn("dbo.LoadConfirmations", "FreightDescription", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LoadConfirmations", "FreightDescription", c => c.String(nullable: false));
            AlterColumn("dbo.LoadConfirmations", "DeliveryCountry", c => c.String(nullable: false));
            AlterColumn("dbo.LoadConfirmations", "DeliveryState", c => c.String(nullable: false));
            AlterColumn("dbo.LoadConfirmations", "DeliveryCity", c => c.String(nullable: false));
            AlterColumn("dbo.LoadConfirmations", "DeliveryAddress", c => c.String(nullable: false));
            AlterColumn("dbo.LoadConfirmations", "DeliveryFacilityName", c => c.String(nullable: false));
            AlterColumn("dbo.LoadConfirmations", "PickUpCountry", c => c.String(nullable: false));
            AlterColumn("dbo.LoadConfirmations", "PickUpState", c => c.String(nullable: false));
            AlterColumn("dbo.LoadConfirmations", "PickUpCity", c => c.String(nullable: false));
            AlterColumn("dbo.LoadConfirmations", "PickUpAddress", c => c.String(nullable: false));
            AlterColumn("dbo.LoadConfirmations", "PickUpFacilityName", c => c.String(nullable: false));
        }
    }
}
