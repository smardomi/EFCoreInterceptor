using EFCoreInterceptor.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreInterceptor.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        public DbSet<Person> People { get; set; }
        
    }
}
