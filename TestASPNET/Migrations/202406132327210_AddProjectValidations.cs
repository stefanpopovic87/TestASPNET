namespace TestASPNET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProjectValidations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projects", "ProjectName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "ProjectName", c => c.String());
        }
    }
}
