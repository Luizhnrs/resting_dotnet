using Microsoft.EntityFrameworkCore;

namespace resting_dotnet.Context
{
    public class ClientDbContext : DbContext
    {
        public ClientDbContext(DbContextOptions options) : base(options)
        { 

        }
        public DbSet<Models.Client> Clients { get; set; }

    }
}
