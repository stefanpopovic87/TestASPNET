namespace TestASPNET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedSupportedImageTypes : DbMigration
    {
        public override void Up()
        {
            // Seed initial data
            Sql("INSERT INTO dbo.\"SupportedImageTypes\" (\"Id\", \"Name\") VALUES (1, 'JPG'), (2, 'DICOM')");
        }

        public override void Down()
        {
            Sql("DELETE FROM dbo.\"SupportedImageTypes\" WHERE \"Id\" IN (1, 2)");
        }
    }
}
