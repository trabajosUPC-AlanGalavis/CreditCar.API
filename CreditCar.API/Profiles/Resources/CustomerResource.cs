using CreditCar.API.Payments.Resources;

namespace CreditCar.API.Profiles.Resources;

public class CustomerResource
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Dni { get; set; }
}