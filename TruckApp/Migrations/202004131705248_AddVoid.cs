namespace TruckApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVoid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LoadConfirmations", "Void", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "Void", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Void");
            DropColumn("dbo.LoadConfirmations", "Void");
        }
    }
}
