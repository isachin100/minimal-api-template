using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace application.Infrastructure.Persistence
{
    public sealed class ApplicationDbContextFactory
    : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(
                    "Server=localhost;Database=dbApplication;Trusted_Connection=True;TrustServerCertificate=True; User Id=sa; Password=Hd1234%^; Connection Timeout=60;")
                .Options;

            return new ApplicationDbContext(options);
        }
    }
}
