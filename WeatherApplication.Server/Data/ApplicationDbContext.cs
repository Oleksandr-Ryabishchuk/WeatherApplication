using Microsoft.EntityFrameworkCore;
using WeatherApplication.Server.Models;

namespace WeatherApplication.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Record> Records { get; set; }
        public DbSet<CurrentWeather> CurrentWeatherCalls { get; set; }
        public DbSet<FiveDaysWeather> FiveDaysWeatherCalls { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Tenant>()
                .HasMany(x => x.Users)
                .WithOne(x => x.Tenant)
                .HasForeignKey(x => x.TenantId);

            builder.Entity<Tenant>()
                .HasMany(x => x.Records)
                .WithOne(x => x.Tenant)
                .HasForeignKey(x => x.TenantId);

            builder.Entity<Tenant>()
                .HasMany(x => x.CurrentWeatherCalls)
                .WithOne(x => x.Tenant)
                .HasForeignKey(x => x.TenantId);

            builder.Entity<Tenant>()
                .HasMany(x => x.FiveDaysWeatherCalls)
                .WithOne(x => x.Tenant)
                .HasForeignKey(x => x.TenantId);

            builder.Entity<FiveDaysWeather>()
                .HasMany(x => x.Items)
                .WithOne(x => x.FiveDaysWeather)
                .HasForeignKey(x => x.FiveDaysWeatherId);
        }
    }
}
