using AutoParts.Infrastructure.Data.Models;
using AutoParts.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AutoParts.Infrastructure.Data
{
    public class AutoPartsDbContext : IdentityDbContext<ApplicationUser>
    {
        public AutoPartsDbContext(DbContextOptions<AutoPartsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Contragent> Contragents { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<DealSubject> DealsSubjects { get; set; }
        public DbSet<StoreHouse> StoreHouses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder
                .Entity<Part>()
                .HasOne(p => p.Category)
                .WithMany(p => p.Parts)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Deal>()
                .HasOne(d => d.Contragent)
                .WithMany(d => d.Deals)
                .HasForeignKey(d => d.ContragentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DealSubject>()
                .HasKey(x => new { x.DealId, x.PartId });

            builder
                .Entity<Part>()
                .Property(p => p.Price)
                .HasPrecision(12, 10);

            builder.Entity<Contragent>()
                .HasIndex(c => c.CustomerNumber)
                .IsUnique();

            base.OnModelCreating(builder);
        }
    }
}