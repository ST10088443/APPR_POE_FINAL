using Disaster_Alleviation_Foundation_App.NewFolder;
using Microsoft.EntityFrameworkCore;

namespace Disaster_Alleviation_Foundation_App.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSet properties for your entity types
        public DbSet<MonetaryDonation> MonetaryDonations { get; set; }
        public DbSet<GoodsDonations> GoodsDonation { get; set; }
        public DbSet<Disaster> Disasters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships, indexes, etc.
            base.OnModelCreating(modelBuilder);
        }
    }
}
