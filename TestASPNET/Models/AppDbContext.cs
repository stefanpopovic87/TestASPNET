using System.Data.Entity;

namespace TestASPNET.Models
{
    [DbConfigurationType(typeof(NpgsqlConfiguration))]
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("DefaultConnection")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<AppDbContext>());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<SupportedImageType> SupportedImageTypes { get; set; }

    }
}
