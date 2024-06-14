namespace TestASPNET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOptionalSupportedImageTypeIdFeature : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "SupportedImageTypeId", "dbo.SupportedImageTypes");
            DropIndex("dbo.Projects", new[] { "SupportedImageTypeId" });
            AlterColumn("dbo.Projects", "SupportedImageTypeId", c => c.Int());
            CreateIndex("dbo.Projects", "SupportedImageTypeId");
            AddForeignKey("dbo.Projects", "SupportedImageTypeId", "dbo.SupportedImageTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "SupportedImageTypeId", "dbo.SupportedImageTypes");
            DropIndex("dbo.Projects", new[] { "SupportedImageTypeId" });
            AlterColumn("dbo.Projects", "SupportedImageTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Projects", "SupportedImageTypeId");
            AddForeignKey("dbo.Projects", "SupportedImageTypeId", "dbo.SupportedImageTypes", "Id", cascadeDelete: true);
        }
    }
}
