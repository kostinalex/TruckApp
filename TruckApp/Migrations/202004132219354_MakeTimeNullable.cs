namespace TruckApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeTimeNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Legs", "DateTime1", c => c.DateTime());
            AlterColumn("dbo.Legs", "DateTime2", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Legs", "DateTime2", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Legs", "DateTime1", c => c.DateTime(nullable: false));
        }
    }
}
