namespace TruckApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClosedAndExported : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LoadConfirmations", "Closed", c => c.Boolean(nullable: false));
            AddColumn("dbo.LoadConfirmations", "Exported", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LoadConfirmations", "Exported");
            DropColumn("dbo.LoadConfirmations", "Closed");
        }
    }
}
