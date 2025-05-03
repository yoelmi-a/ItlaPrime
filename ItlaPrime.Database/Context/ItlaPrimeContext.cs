using ItlaPrime.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace ItlaPrime.Database.Context
{
    public class ItlaPrimeContext : DbContext
    {
        public ItlaPrimeContext(DbContextOptions<ItlaPrimeContext> options) : base(options) { }

        public DbSet<Series> Series { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Fluent API

            #region Tables
            modelBuilder.Entity<Series>().ToTable("Series");
            modelBuilder.Entity<Producer>().ToTable("Producers");
            modelBuilder.Entity<Genre>().ToTable("Genres");
            #endregion

            #region Primary Keys
            modelBuilder.Entity<Producer>().HasKey(p => p.Id);
            modelBuilder.Entity<Series>().HasKey(s => s.Id);
            modelBuilder.Entity<Genre>().HasKey(g => g.Id);
            #endregion

            #region Relationships
            modelBuilder.Entity<Producer>()
                .HasMany<Series>(p => p.Series)
                .WithOne(s => s.Producer)
                .HasForeignKey(p => p.ProducerID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Genre>()
                .HasMany<Series>(g => g.PrimarySeries)
                .WithOne(s => s.PrimaryGenre)
                .HasForeignKey(s => s.PrimaryGenreID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Genre>()
                .HasMany<Series>(g => g.SecondarySeries)
                .WithOne(s => s.SecondaryGenre)
                .HasForeignKey(s => s.SecondaryGenreID)
                .OnDelete(DeleteBehavior.SetNull);
            #endregion

            #region Properties configuration
            modelBuilder.Entity<Series>()
                .Property(s => s.Name).HasMaxLength(50);

            modelBuilder.Entity<Genre>()
                .Property(g => g.Name).HasMaxLength(50);

            modelBuilder.Entity<Producer>()
                .Property(p => p.Name).HasMaxLength(50);
            #endregion
        }
    }
}
