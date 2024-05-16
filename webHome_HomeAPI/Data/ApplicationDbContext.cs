using Microsoft.EntityFrameworkCore;
using webHome_HomeAPI.Models;

namespace webHome_HomeAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Home> Homes { get; set; }
    }
}
