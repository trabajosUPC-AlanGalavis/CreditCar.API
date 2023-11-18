using CreditCar.API.Payments.Domain.Models;
using CreditCar.API.Vehicles.Domain.Models;

namespace CreditCar.API.Profiles.Domain.Models;

public class Dealership
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    // Relationships
    
    public IList<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    public IList<Payment> Payments { get; set; } = new List<Payment>();
}