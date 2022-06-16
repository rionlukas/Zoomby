using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Zoomby.Models.Master;
using Zoomby.Models.Transaction;

namespace Zoomby.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pic> Pic { get; set; }
        public DbSet<ZoomAccount> ZoomAccounts { get; set; }
        public DbSet<ZoomScheduler> ZoomScheduler { get; set; }
        
    }
}