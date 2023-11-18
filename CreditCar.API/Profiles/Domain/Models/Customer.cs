using CreditCar.API.Payments.Domain.Models;

namespace CreditCar.API.Profiles.Domain.Models;

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Dni { get; set; }
    
    // Relationships
    
    public IList<Payment> Payments { get; set; } = new List<Payment>();
}