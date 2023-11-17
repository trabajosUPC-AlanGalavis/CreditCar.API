using Microsoft.EntityFrameworkCore;
using CreditCar.API.Profiles.Domain.Models;
using CreditCar.API.Shared.Extensions;
using CreditCar.API.Vehicles.Domain.Models;

namespace CreditCar.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Users
        
        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(p => p.Id);
        builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(p => p.FirstName).IsRequired();
        builder.Entity<User>().Property(p => p.LastName).IsRequired();
        builder.Entity<User>().Property(p => p.Email).IsRequired();
        builder.Entity<User>().Property(p => p.Password).IsRequired();
        
        // Vehicles
        
        builder.Entity<Vehicle>().ToTable("Vehicles");
        builder.Entity<Vehicle>().HasKey(p => p.Id);
        builder.Entity<Vehicle>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Vehicle>().Property(p => p.Brand).IsRequired();
        builder.Entity<Vehicle>().Property(p => p.Model).IsRequired();
        builder.Entity<Vehicle>().Property(p => p.Image).IsRequired();
        builder.Entity<Vehicle>().Property(p => p.Price).IsRequired();
        
        // Apply Snake Case Naming Convention
        
        builder.UseSnakeCaseNamingConvention();
    }
}