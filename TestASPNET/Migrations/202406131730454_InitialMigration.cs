namespace TestASPNET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(),
                        ProjectEnabled = c.Boolean(nullable: false),
                        AcceptingNewVisits = c.Boolean(nullable: false),
                        SupportedImageTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SupportedImageTypes", t => t.SupportedImageTypeId, cascadeDelete: true)
                .Index(t => t.SupportedImageTypeId);
            
            CreateTable(
                "dbo.SupportedImageTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "SupportedImageTypeId", "dbo.SupportedImageTypes");
            DropIndex("dbo.Projects", new[] { "SupportedImageTypeId" });
            DropTable("dbo.Users");
            DropTable("dbo.SupportedImageTypes");
            DropTable("dbo.Projects");
        }
    }
}
