using DotNet_Microservices.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNet_Microservices.Data
{
    public class AppDbContext : DbContext{
        public AppDbContext(DbContextOptions<AppDbContext> opt)
        : base(opt)
        {
            
        }

        public DbSet<Platform> Platforms { get; set; }
    }
}