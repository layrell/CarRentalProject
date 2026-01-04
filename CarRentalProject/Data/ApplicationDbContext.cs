using CarRentalProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarRentalProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Sedan" },
                new Category { Id = 2, Name = "SUV" }
            );

            builder.Entity<Car>().HasData(
                new Car { Id = 1, Brand = "Toyota", Model = "Corolla", PricePerDay = 150, CategoryId = 1, IsAvailable = true },
                new Car { Id = 2, Brand = "BMW", Model = "X5", PricePerDay = 400, CategoryId = 2, IsAvailable = true }
            );
        }
    }
}