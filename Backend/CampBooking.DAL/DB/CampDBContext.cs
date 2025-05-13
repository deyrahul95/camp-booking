using CampBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CampBooking.DAL.DB
{
    public class CampDBContext : DbContext 
    {
        public CampDBContext(DbContextOptions<CampDBContext> options) : base(options)
        {
            
        }

        public DbSet<Camp> Camps { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BookingDetails> BookingDetails { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new DbInitializer(modelBuilder).Seed();
        }
    }

    // seed data to database 
    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            modelBuilder.Entity<User>().HasData(
                   new User() { Id = 1,Name="Admin",Email="admin@gmail.com",Password="admin@123",IsAdmin=true },
                   new User() { Id = 2, Name = "Rahul", Email = "rahul@gmail.com", Password = "rahul@123", IsAdmin = false },
                   new User() { Id = 3, Name = "Admin App", Email = "admin@campbooking.com", Password = "admin@123", IsAdmin = true },
                   new User() { Id = 4, Name = "Test User", Email = "test@gmail.com", Password = "test@123", IsAdmin = false }
            );
        }
    }

}
