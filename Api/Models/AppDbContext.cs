using Microsoft.EntityFrameworkCore;
using System;

namespace Api.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Seeds
            modelBuilder.Entity<Category>().HasData(new[] {
                new Category { Id = 1, Name = "Automobile", Description = "Lorem ipsum dolor sit amet.", CreatedOn = DateTime.Now },
                new Category { Id = 2, Name = "Suv", Description = "Lorem ipsum dolor sit amet.", CreatedOn = DateTime.Now.AddDays(-30) },
                new Category { Id = 3, Name = "Truck", Description = "Lorem ipsum dolor sit amet.", CreatedOn = DateTime.Now.AddDays(-60) }
            });

            modelBuilder.Entity<Manufacturer>().HasData(new[] {
                new Manufacturer { Id = 1, Name = "Bmw", CreatedOn = DateTime.Now },
                new Manufacturer { Id = 2, Name = "Volvo", CreatedOn = DateTime.Now.AddDays(-10) },
                new Manufacturer { Id = 3, Name = "Nissan", CreatedOn = DateTime.Now.AddDays(-20) },
                new Manufacturer { Id = 4, Name = "Toyota", CreatedOn = DateTime.Now.AddDays(-30) },
                new Manufacturer { Id = 5, Name = "Mazda", CreatedOn = DateTime.Now.AddDays(-40)}
            });

            modelBuilder.Entity<Vehicle>().HasData(new[] {
                new Vehicle { Id = 1, ManufacturerId = 1, CategoryId = 1, Generation = "3 Series Sedan (E46, facelift 2001)", Engine = 170, Model = "3 Series", BodyType = "Sedan", Year = 2005, Color = "Red", Seats = 5, Doors = 4, CreatedOn = DateTime.Now.AddYears(-3) },
                new Vehicle { Id = 2, ManufacturerId = 1, CategoryId = 1, Generation = "1 Series Hatchback (F40)", Engine = 109, Model = "1 Series", BodyType = "Hatchback", Year = 2020, Color = "Black", Seats = 5, Doors = 5, CreatedOn = DateTime.Now.AddDays(-5) },
                new Vehicle { Id = 3, ManufacturerId = 2, CategoryId = 2, Generation = "XC90 II", Engine = 408, Model = "XC90", BodyType = "SUV", Year = 2018, Color = "Black", Seats = 5, Doors = 5, CreatedOn = DateTime.Now.AddMonths(-3) },
                new Vehicle { Id = 4, ManufacturerId = 2, CategoryId = 1, Generation = "S90 (facelift 2020)", Engine = 150, Model = "S90", BodyType = "Sedan", Year = 2020, Color = "Gray", Seats = 5, Doors = 4, CreatedOn = DateTime.Now.AddMonths(-2) },
                new Vehicle { Id = 5, ManufacturerId = 2, CategoryId = 3, Generation = "FH", Engine = 500, Model = "500", BodyType = "Truck", Year = 2020, Color = "White", Seats = 2, Doors = 2, CreatedOn = DateTime.Now.AddDays(-10) },
                new Vehicle { Id = 6, ManufacturerId = 3, CategoryId = 1, Generation = "Skyline X (R34)", Engine = 200, Model = "Skyline", BodyType = "Sedan", Year = 2001, Color = "Blue", Seats = 5, Doors = 4, CreatedOn = DateTime.Now.AddYears(-20) },                
                new Vehicle { Id = 7, ManufacturerId = 4, CategoryId = 1, Generation = "AE86", Engine = 195, Model = "AE86", BodyType = "Coupe", Year = 2005, Color = "Red", Seats = 5, Doors = 2, CreatedOn = DateTime.Now.AddMonths(-6) },
                new Vehicle { Id = 8, ManufacturerId = 5, CategoryId = 1, Generation = "RX-8", Engine = 250, Model = "RX-8", BodyType = "Coupe", Year = 2009, Color = "Red", Seats = 4, Doors = 2, CreatedOn = DateTime.Now.AddYears(-10) }
            });
            #endregion
        }
    }
}
