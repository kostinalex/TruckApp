namespace TruckApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTimeDistanceRateToLeg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Legs", "DateTime1", c => c.DateTime(nullable: false));
            AddColumn("dbo.Legs", "DateTime2", c => c.DateTime(nullable: false));
            AddColumn("dbo.Legs", "Distance", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Legs", "DriverPay", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Legs", "DriverPay");
            DropColumn("dbo.Legs", "Distance");
            DropColumn("dbo.Legs", "DateTime2");
            DropColumn("dbo.Legs", "DateTime1");
        }
    }
}
