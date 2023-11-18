using System.ComponentModel.DataAnnotations;

namespace CreditCar.API.Profiles.Resources;

public class SaveCustomerResource
{
  [Required]
  public string FirstName { get; set; }
  [Required]
  public string LastName { get; set; }
  [Required]
  public int Dni { get; set; }
}