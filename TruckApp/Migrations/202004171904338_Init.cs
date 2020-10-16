namespace TruckApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
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
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LoadConfirmations", t => t.LoadConfirmationId, cascadeDelete: true)
                .Index(t => t.LoadConfirmationId);
            
            CreateTable(
                "dbo.LoadConfirmations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        FreightDescription = c.String(),
                        Weight = c.Int(nullable: false),
                        NumberOfPallets = c.Byte(nullable: false),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HazMatStatusId = c.Int(nullable: false),
                        EquipmentId = c.Int(nullable: false),
                        PriorityDeliveryId = c.Int(nullable: false),
                        PriorityEntryId = c.Int(nullable: false),
                        DispatchId = c.Int(nullable: false),
                        CreditHold = c.Boolean(nullable: false),
                        POD = c.Boolean(nullable: false),
                        ConfNumber = c.String(),
                        CustomsBroker = c.String(),
                        HazMatNumber = c.Int(),
                        Void = c.Boolean(nullable: false),
                        Closed = c.Boolean(nullable: false),
                        Exported = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Dispatches", t => t.DispatchId, cascadeDelete: true)
                .ForeignKey("dbo.Equipments", t => t.EquipmentId, cascadeDelete: true)
                .ForeignKey("dbo.HazMatStatus", t => t.HazMatStatusId, cascadeDelete: true)
                .ForeignKey("dbo.PriorityDeliveries", t => t.PriorityDeliveryId, cascadeDelete: true)
                .ForeignKey("dbo.PriorityEntries", t => t.PriorityEntryId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.HazMatStatusId)
                .Index(t => t.EquipmentId)
                .Index(t => t.PriorityDeliveryId)
                .Index(t => t.PriorityEntryId)
                .Index(t => t.DispatchId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        Zipcode = c.String(),
                        Void = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Dispatches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HazMatStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PriorityDeliveries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PriorityEntries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Legs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Stop1Id = c.Int(nullable: false),
                        Stop2Id = c.Int(nullable: false),
                        DriverId = c.Int(),
                        LoadConfirmationId = c.Int(nullable: false),
                        DateTime1 = c.DateTime(),
                        DateTime2 = c.DateTime(),
                        Distance = c.Decimal(precision: 18, scale: 2),
                        DriverPay = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drivers", t => t.DriverId)
                .ForeignKey("dbo.LoadConfirmations", t => t.LoadConfirmationId, cascadeDelete: true)
                .ForeignKey("dbo.Stops", t => t.Stop1Id)
                .ForeignKey("dbo.Stops", t => t.Stop2Id)
                .Index(t => t.Stop1Id)
                .Index(t => t.Stop2Id)
                .Index(t => t.DriverId)
                .Index(t => t.LoadConfirmationId);
            
            CreateTable(
                "dbo.Stops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoadConfirmationId = c.Int(nullable: false),
                        OrderNumber = c.Byte(nullable: false),
                        PUStatus = c.Boolean(nullable: false),
                        DelStatus = c.Boolean(nullable: false),
                        FacilityName = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        ZipCode = c.String(),
                        Date1 = c.DateTime(nullable: false),
                        Date2 = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LoadConfirmations", t => t.LoadConfirmationId, cascadeDelete: true)
                .Index(t => t.LoadConfirmationId);
            
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NoteContent = c.String(nullable: false),
                        LoadConfirmationId = c.Int(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        Header = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LoadConfirmations", t => t.LoadConfirmationId, cascadeDelete: true)
                .Index(t => t.LoadConfirmationId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.UserActions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Action = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        LoadConfirmationId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LoadConfirmations", t => t.LoadConfirmationId)
                .Index(t => t.LoadConfirmationId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        DarkTheme = c.Boolean(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserActions", "LoadConfirmationId", "dbo.LoadConfirmations");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Notes", "LoadConfirmationId", "dbo.LoadConfirmations");
            DropForeignKey("dbo.Legs", "Stop2Id", "dbo.Stops");
            DropForeignKey("dbo.Legs", "Stop1Id", "dbo.Stops");
            DropForeignKey("dbo.Stops", "LoadConfirmationId", "dbo.LoadConfirmations");
            DropForeignKey("dbo.Legs", "LoadConfirmationId", "dbo.LoadConfirmations");
            DropForeignKey("dbo.Legs", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.Attachments", "LoadConfirmationId", "dbo.LoadConfirmations");
            DropForeignKey("dbo.LoadConfirmations", "PriorityEntryId", "dbo.PriorityEntries");
            DropForeignKey("dbo.LoadConfirmations", "PriorityDeliveryId", "dbo.PriorityDeliveries");
            DropForeignKey("dbo.LoadConfirmations", "HazMatStatusId", "dbo.HazMatStatus");
            DropForeignKey("dbo.LoadConfirmations", "EquipmentId", "dbo.Equipments");
            DropForeignKey("dbo.LoadConfirmations", "DispatchId", "dbo.Dispatches");
            DropForeignKey("dbo.LoadConfirmations", "CustomerId", "dbo.Customers");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.UserActions", new[] { "LoadConfirmationId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Notes", new[] { "LoadConfirmationId" });
            DropIndex("dbo.Stops", new[] { "LoadConfirmationId" });
            DropIndex("dbo.Legs", new[] { "LoadConfirmationId" });
            DropIndex("dbo.Legs", new[] { "DriverId" });
            DropIndex("dbo.Legs", new[] { "Stop2Id" });
            DropIndex("dbo.Legs", new[] { "Stop1Id" });
            DropIndex("dbo.LoadConfirmations", new[] { "DispatchId" });
            DropIndex("dbo.LoadConfirmations", new[] { "PriorityEntryId" });
            DropIndex("dbo.LoadConfirmations", new[] { "PriorityDeliveryId" });
            DropIndex("dbo.LoadConfirmations", new[] { "EquipmentId" });
            DropIndex("dbo.LoadConfirmations", new[] { "HazMatStatusId" });
            DropIndex("dbo.LoadConfirmations", new[] { "CustomerId" });
            DropIndex("dbo.Attachments", new[] { "LoadConfirmationId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UserActions");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Notes");
            DropTable("dbo.Stops");
            DropTable("dbo.Legs");
            DropTable("dbo.Drivers");
            DropTable("dbo.PriorityEntries");
            DropTable("dbo.PriorityDeliveries");
            DropTable("dbo.HazMatStatus");
            DropTable("dbo.Equipments");
            DropTable("dbo.Dispatches");
            DropTable("dbo.Customers");
            DropTable("dbo.LoadConfirmations");
            DropTable("dbo.Attachments");
        }
    }
}
