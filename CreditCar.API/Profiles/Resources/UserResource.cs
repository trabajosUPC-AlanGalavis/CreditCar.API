using CreditCar.API.Payments.Resources;

namespace CreditCar.API.Profiles.Resources;

public class UserResource
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public int Dni { get; set; }
    public int ZipCode { get; set; }
    public PaymentResource Payment { get; set; }
}