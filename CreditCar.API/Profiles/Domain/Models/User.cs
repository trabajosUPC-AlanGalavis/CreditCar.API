namespace CreditCar.API.Profiles.Domain.Models;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    
    public int Dni { get; set; }
    
    public int ZipCode { get; set; }
    
    // Relationships
    
    //public int PlanId { get; set; }
    
    //public IList<Plan> Plans { get; set; } = new List<Plan>();
}