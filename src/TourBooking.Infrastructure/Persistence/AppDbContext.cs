using Microsoft.EntityFrameworkCore;
using TourBooking.Domain.Entities;

namespace TourBooking.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Tour> Tours => Set<Tour>();
    public DbSet<Booking> Bookings => Set<Booking>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tour>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Name).IsRequired().HasMaxLength(200);
            entity.Property(x => x.Location).IsRequired().HasMaxLength(200);

            entity.Property(x => x.Price).HasPrecision(18, 2);

            entity.Property(x => x.Capacity).IsRequired();
            entity.Property(x => x.AvailableSlots).IsRequired();
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.CustomerName).IsRequired().HasMaxLength(200);
            entity.Property(x => x.CustomerEmail).IsRequired().HasMaxLength(200);

            entity.HasOne(x => x.Tour)
                  .WithMany()
                  .HasForeignKey(x => x.TourId);
        });
    }
}
