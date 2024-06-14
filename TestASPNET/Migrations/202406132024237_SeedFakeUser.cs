namespace TestASPNET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedFakeUser : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.\"Users\" (\"Id\", \"Username\", \"Password\") VALUES (1, 'Admin', 'password')");
        }

        public override void Down()
        {
            Sql("DELETE FROM dbo.\"Users\" WHERE \"Id\" = 1");
        }
    }
}
