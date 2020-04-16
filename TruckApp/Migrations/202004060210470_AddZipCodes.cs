namespace TruckApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddZipCodes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LoadConfirmations", "PickUpZipcode", c => c.String());
            AddColumn("dbo.LoadConfirmations", "DeliveryZipcode", c => c.String());
            AddColumn("dbo.Customers", "Zipcode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Zipcode");
            DropColumn("dbo.LoadConfirmations", "DeliveryZipcode");
            DropColumn("dbo.LoadConfirmations", "PickUpZipcode");
        }
    }
}
