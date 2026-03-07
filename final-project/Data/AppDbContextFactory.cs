using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace final_project.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var connectionString =
                "server=localhost;port=3306;database=csharp_course_management;user=root;password=Iloveyouforever@096;";

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            optionsBuilder.UseMySql(
                connectionString,
                ServerVersion.AutoDetect(connectionString)
            );

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}