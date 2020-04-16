namespace TruckApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAttachments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attachments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoadConfirmationId = c.Int(nullable: false),
                        Path = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LoadConfirmations", t => t.LoadConfirmationId, cascadeDelete: true)
                .Index(t => t.LoadConfirmationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attachments", "LoadConfirmationId", "dbo.LoadConfirmations");
            DropIndex("dbo.Attachments", new[] { "LoadConfirmationId" });
            DropTable("dbo.Attachments");
        }
    }
}
