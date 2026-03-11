using Microsoft.EntityFrameworkCore;
using YourNamespace.Models;

namespace YourNamespace.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Citizen> Citizens { get; set; }  // DbSet for Citizen
        public DbSet<ServiceRequest> ServiceRequests { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Report> Reports { get; set; }

        // Other DbSets and configurations if needed
    }
}
