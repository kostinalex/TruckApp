namespace TruckApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HazMatNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LoadConfirmations", "HazMatNumber", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LoadConfirmations", "HazMatNumber", c => c.Int(nullable: false));
        }
    }
}
