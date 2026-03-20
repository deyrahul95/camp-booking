using CampBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CampBooking.DAL.DB;

/// <summary>
/// Entity Framework Core database context for the camp‑booking application.
/// </summary>
/// <param name="options">Configuration options for the context.</param>
public class CampDBContext(DbContextOptions<CampDBContext> options) : DbContext(options)
{
    /// <summary>Camp entities.</summary>
    public DbSet<Camp> Camps { get; set; }

    /// <summary>User entities.</summary>
    public DbSet<User> Users { get; set; }

    /// <summary>Booking details entities.</summary>
    public DbSet<BookingDetails> BookingDetails { get; set; }

    /// <summary>Rating entities.</summary>
    public DbSet<Rating> Ratings { get; set; }

    /// <summary>
    /// Configures the model and seeds initial data.
    /// </summary>
    /// <param name="modelBuilder">The model builder used to configure entity mappings.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new DbInitializer(modelBuilder).Seed();
    }
}

/// <summary>
/// Initializes a new instance with the provided <see cref="ModelBuilder"/>.
/// </summary>
/// <param name="modelBuilder">The model builder used for seeding.</param>
public class DbInitializer(ModelBuilder modelBuilder)
{
    private readonly ModelBuilder modelBuilder = modelBuilder;

    /// <summary>
    /// Adds predefined <c>User</c> records to the model.
    /// </summary>
    public void Seed()
    {
        modelBuilder.Entity<User>().HasData(
            new User() { Id = 1, Name = "Admin", Email = "admin@gmail.com", Password = "admin@123", IsAdmin = true },
            new User() { Id = 2, Name = "Rahul", Email = "rahul@gmail.com", Password = "rahul@123", IsAdmin = false },
            new User() { Id = 3, Name = "Admin App", Email = "admin@campbooking.com", Password = "admin@123", IsAdmin = true },
            new User() { Id = 4, Name = "Test User", Email = "test@gmail.com", Password = "test@123", IsAdmin = false }
        );
    }
}
