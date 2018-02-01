namespace TeknikServis.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Faults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        UserId = c.String(maxLength: 128),
                        OperatorId = c.String(maxLength: 128),
                        TechnicianId = c.String(maxLength: 128),
                        Title = c.String(nullable: false),
                        Report = c.String(),
                        Location = c.String(nullable: false),
                        AddressDescription = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.OperatorId)
                .ForeignKey("dbo.AspNetUsers", t => t.TechnicianId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.OperatorId)
                .Index(t => t.TechnicianId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 25),
                        SurName = c.String(maxLength: 25),
                        RegisterDate = c.DateTime(nullable: false),
                        ActivationCode = c.String(),
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
                "dbo.SurveyAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionAnswer = c.Int(),
                        QuestionId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sorular", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.QuestionId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Sorular",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionText = c.String(nullable: false),
                        SurveyId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Surveys", t => t.SurveyId, cascadeDelete: true)
                .Index(t => t.SurveyId);
            
            CreateTable(
                "dbo.Surveys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SurveyName = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        URL = c.String(nullable: false),
                        FaultId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Faults", t => t.FaultId, cascadeDelete: true)
                .Index(t => t.FaultId);
            
            CreateTable(
                "dbo.FaultStatuses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FaultId = c.Int(nullable: false),
                        Description = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        Status_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Faults", t => t.FaultId, cascadeDelete: true)
                .ForeignKey("dbo.FaultStatuses", t => t.Status_Id)
                .Index(t => t.FaultId)
                .Index(t => t.Status_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(maxLength: 200),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Faults", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Faults", "TechnicianId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FaultStatuses", "Status_Id", "dbo.FaultStatuses");
            DropForeignKey("dbo.FaultStatuses", "FaultId", "dbo.Faults");
            DropForeignKey("dbo.Photos", "FaultId", "dbo.Faults");
            DropForeignKey("dbo.Faults", "OperatorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.SurveyAnswers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Sorular", "SurveyId", "dbo.Surveys");
            DropForeignKey("dbo.SurveyAnswers", "QuestionId", "dbo.Sorular");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.FaultStatuses", new[] { "Status_Id" });
            DropIndex("dbo.FaultStatuses", new[] { "FaultId" });
            DropIndex("dbo.Photos", new[] { "FaultId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.Sorular", new[] { "SurveyId" });
            DropIndex("dbo.SurveyAnswers", new[] { "UserId" });
            DropIndex("dbo.SurveyAnswers", new[] { "QuestionId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Faults", new[] { "TechnicianId" });
            DropIndex("dbo.Faults", new[] { "OperatorId" });
            DropIndex("dbo.Faults", new[] { "UserId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.FaultStatuses");
            DropTable("dbo.Photos");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.Surveys");
            DropTable("dbo.Sorular");
            DropTable("dbo.SurveyAnswers");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Faults");
        }
    }
}
