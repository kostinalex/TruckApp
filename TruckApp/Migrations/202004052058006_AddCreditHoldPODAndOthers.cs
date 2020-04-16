namespace TruckApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreditHoldPODAndOthers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LoadConfirmations", "CreditHold", c => c.Boolean(nullable: false));
            AddColumn("dbo.LoadConfirmations", "POD", c => c.Boolean(nullable: false));
            AddColumn("dbo.LoadConfirmations", "ConfNumber", c => c.String());
            AddColumn("dbo.LoadConfirmations", "CustomsBroker", c => c.String());
            AddColumn("dbo.LoadConfirmations", "HazMatNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LoadConfirmations", "HazMatNumber");
            DropColumn("dbo.LoadConfirmations", "CustomsBroker");
            DropColumn("dbo.LoadConfirmations", "ConfNumber");
            DropColumn("dbo.LoadConfirmations", "POD");
            DropColumn("dbo.LoadConfirmations", "CreditHold");
        }
    }
}
