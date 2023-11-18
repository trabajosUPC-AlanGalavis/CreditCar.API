using CreditCar.API.Payments.Domain.Models;

namespace CreditCar.API.Vehicles.Domain.Models;

public class Vehicle
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Image { get; set; }
    public int Price { get; set; }
    
    // Relationships
    
    public IList<Payment> Payments { get; set; } = new List<Payment>();
}