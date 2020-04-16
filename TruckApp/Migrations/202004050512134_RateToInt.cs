namespace TruckApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RateToInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LoadConfirmations", "Rate", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LoadConfirmations", "Rate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
