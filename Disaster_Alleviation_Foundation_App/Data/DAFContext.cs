using Disaster_Alleviation_Foundation_App.Models;
using Disaster_Alleviation_Foundation_App.NewFolder;
using Microsoft.EntityFrameworkCore;
namespace Disaster_Alleviation_Foundation_App.Data
{
    public class DAFContext:DbContext
    {
        public DAFContext(DbContextOptions<DAFContext> options) : base(options) { }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Disaster> Disaster { get; set; }
        public DbSet<GoodsCategory> GoodsCategory { get; set; }
        public DbSet<GoodsDonations> GoodsDonation { get; set; }
        public DbSet<MonetaryDonation> MonetaryDonation { get; set; }
        public DbSet<AidType> AidType { get; set; }
        public DbSet<DisasterAidType> DisasterAidType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DisasterAidType>()
                .HasKey(da => new { da.DisasterId, da.AidTypeId });

            modelBuilder.Entity<DisasterAidType>()
                .HasOne(da => da.Disaster)
                .WithMany(d => d.DisasterAidTypes)
                .HasForeignKey(da => da.DisasterId);

            modelBuilder.Entity<DisasterAidType>()
                .HasOne(da => da.AidType)
                .WithMany(a => a.DisasterAidTypes)
                .HasForeignKey(da => da.AidTypeId);
        }

    }
}
