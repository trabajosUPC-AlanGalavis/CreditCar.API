using CreditCar.API.Payments.Domain.Models;
using Microsoft.EntityFrameworkCore;
using CreditCar.API.Profiles.Domain.Models;
using CreditCar.API.Shared.Extensions;
using CreditCar.API.Vehicles.Domain.Models;

namespace CreditCar.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Customer> Users { get; set; }
    public DbSet<Dealership> Dealerships { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Payment> Payments { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Users
        
        builder.Entity<Customer>().ToTable("Users");
        builder.Entity<Customer>().HasKey(p => p.Id);
        builder.Entity<Customer>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Customer>().Property(p => p.FirstName).IsRequired();
        builder.Entity<Customer>().Property(p => p.LastName).IsRequired();
        
        // Dealership
        
        builder.Entity<Dealership>().ToTable("Dealership");
        builder.Entity<Dealership>().HasKey(p => p.Id);
        builder.Entity<Dealership>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Dealership>().Property(p => p.Name).IsRequired();
        
        // Vehicles
        
        builder.Entity<Vehicle>().ToTable("Vehicles");
        builder.Entity<Vehicle>().HasKey(p => p.Id);
        builder.Entity<Vehicle>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Vehicle>().Property(p => p.Brand).IsRequired();
        builder.Entity<Vehicle>().Property(p => p.Model).IsRequired();
        builder.Entity<Vehicle>().Property(p => p.Image).IsRequired();
        builder.Entity<Vehicle>().Property(p => p.Price).IsRequired();
        
        // Payments
        
        builder.Entity<Payment>().ToTable("Payments");
        builder.Entity<Payment>().HasKey(p => p.Id);
        builder.Entity<Payment>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Payment>().Property(p => p.Currency).IsRequired();
        builder.Entity<Payment>().Property(p => p.RateType).IsRequired();
        builder.Entity<Payment>().Property(p => p.SelectedRate).IsRequired();
        builder.Entity<Payment>().Property(p => p.SelectedPeriod).IsRequired();
        builder.Entity<Payment>().Property(p => p.RateValue).IsRequired();
        builder.Entity<Payment>().Property(p => p.ClosingDate).IsRequired();
        builder.Entity<Payment>().Property(p => p.TotalGracePeriod).IsRequired();
        builder.Entity<Payment>().Property(p => p.PartialGracePeriod).IsRequired();
        builder.Entity<Payment>().Property(p => p.InitialFee).IsRequired();
        builder.Entity<Payment>().Property(p => p.FinalFee).IsRequired();
        builder.Entity<Payment>().Property(p => p.CreditLifeInsurance).IsRequired();
        builder.Entity<Payment>().Property(p => p.VehicleInsurance).IsRequired();
        builder.Entity<Payment>().Property(p => p.CreateDate).IsRequired();
        builder.Entity<Payment>().Property(p => p.FormattedRateValue).IsRequired();
        builder.Entity<Payment>().Property(p => p.Cok).IsRequired();
        builder.Entity<Payment>().Property(p => p.Van).IsRequired();
        builder.Entity<Payment>().Property(p => p.Tea).IsRequired();
        builder.Entity<Payment>().Property(p => p.Tcea).IsRequired();
        builder.Entity<Payment>().Property(p => p.Tir).IsRequired();
        
        // Relationships
        builder.Entity<Customer>()
            .HasMany(p => p.Payments)
            .WithOne(p => p.Customer)
            .HasForeignKey(p => p.CustomerId);
        
        builder.Entity<Vehicle>()
            .HasMany(p => p.Payments)
            .WithOne(p => p.Vehicle)
            .HasForeignKey(p => p.VehicleId);
        
        builder.Entity<Dealership>()
            .HasMany(p => p.Payments)
            .WithOne(p => p.Dealership)
            .HasForeignKey(p => p.DealershipId);
        
        // Apply Snake Case Naming Convention
        
        builder.UseSnakeCaseNamingConvention();
    }
}