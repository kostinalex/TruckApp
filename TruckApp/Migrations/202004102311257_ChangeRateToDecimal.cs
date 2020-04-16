namespace TruckApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeRateToDecimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LoadConfirmations", "Rate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LoadConfirmations", "Rate", c => c.Int(nullable: false));
        }
    }
}
