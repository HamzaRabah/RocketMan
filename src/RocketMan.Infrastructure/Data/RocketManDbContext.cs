using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RocketMan.Core.Entities;

namespace RocketMan.Infrastructure.Data
{
    public class RocketManDbContext : DbContext
    {
        public RocketManDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Launch> FavoriteLaunches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Launch>(ConfigureLaunch);
        }

        private void ConfigureLaunch(EntityTypeBuilder<Launch> builder)
        {
            //builder.ToTable("FavoriteLaunch");

            builder.HasKey(ci => ci.Id);
        }
    }
}