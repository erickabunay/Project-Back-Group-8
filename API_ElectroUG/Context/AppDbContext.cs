using Microsoft.EntityFrameworkCore;
using API_ElectroUG.Models;
using Microsoft.EntityFrameworkCore.Design;

namespace API_ElectroUG.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=ANGELO\SQLEXPRESS;Database=ElectroUG;Integrated Security=True;TrustServerCertificate=True;");

        }
        public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
        {
            public AppDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                optionsBuilder.UseSqlServer(@"Server=ANGELO\SQLEXPRESS;Database=ElectroUG;Integrated Security=True;TrustServerCertificate=True;");

                return new AppDbContext(optionsBuilder.Options);
            }
        }


        public DbSet<User> User { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }

    }
}
