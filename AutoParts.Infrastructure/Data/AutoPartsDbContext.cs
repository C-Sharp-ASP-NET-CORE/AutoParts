using AutoParts.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AutoParts.Infrastructure.Data
{
    public class AutoPartsDbContext : IdentityDbContext
    {
        public AutoPartsDbContext(DbContextOptions<AutoPartsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Part> Parts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Part>()
                .HasOne(p => p.Category)
                .WithMany(p => p.Parts)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Part>()
                .Property(p => p.Price)
                .HasPrecision(12, 10);

            base.OnModelCreating(builder);
        }
    }
}