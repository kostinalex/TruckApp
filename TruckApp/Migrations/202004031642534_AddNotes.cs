namespace TruckApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNotes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NoteContent = c.String(nullable: false),
                        LoadConfirmationId = c.Int(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LoadConfirmations", t => t.LoadConfirmationId, cascadeDelete: true)
                .Index(t => t.LoadConfirmationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notes", "LoadConfirmationId", "dbo.LoadConfirmations");
            DropIndex("dbo.Notes", new[] { "LoadConfirmationId" });
            DropTable("dbo.Notes");
        }
    }
}
