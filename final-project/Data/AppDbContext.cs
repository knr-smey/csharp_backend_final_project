using Microsoft.EntityFrameworkCore;

namespace final_project.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Put table here from model
        //public DbSet<TestUser> TestUsers { get; set; }
    }
}