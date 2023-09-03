using Microsoft.EntityFrameworkCore;
using Elements.Domain.Models;

using static Elements.Persistence.DatabasePathHelper;

namespace Elements.Persistence
{
    public class Context : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Reminder> Reminders { get; set; }
        public DbSet<Update> Updates { get; set; }
        public DbSet<Disclaimer> Disclaimers { get; set; }

        protected override void OnConfiguring
            (DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DatabasePath()}");
            SQLitePCL.Batteries.Init();
        }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>(
                entity =>
            {
                entity.HasIndex(e => e.Id);
                entity.OwnsOne(e => e.Title)
                    .Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.OwnsOne(e => e.ImageName)
                    .Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Section>(
                entity =>
            {
                entity.ToTable("Sections");
                entity.HasIndex(e => e.Id);
                entity.OwnsOne(e => e.Header)
                    .Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.OwnsOne(e => e.Text)
                    .Property(e => e.Value)
                    .IsRequired();
                entity.OwnsOne(e => e.Order)
                    .Property(e => e.Value)
                    .IsRequired();
            });

            modelBuilder.Entity<Reminder>(
                entity =>
            {
                entity.HasIndex(e => e.Id);
                entity.OwnsOne(e => e.Title)
                    .Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.OwnsOne(e => e.PlatformId)
                    .Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Disclaimer>(
                entity =>
                {
                    entity.HasIndex(e => e.Id);
                    entity.OwnsOne(e => e.Message)
                        .Property(e => e.Value)
                        .IsRequired();
                });

            modelBuilder.Entity<Update>(
                entity =>
                {
                    entity.HasIndex(e => e.Id);
                    entity.HasIndex(e => e.Value);
                    entity.Property(e => e.Value)
                        .IsRequired()
                        .HasMaxLength(50);
                });
        }
    }

    public static class ContextConstructor
    {
        public static Context Context()
            => new();
    }
}