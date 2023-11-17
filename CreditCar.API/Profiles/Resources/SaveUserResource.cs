using System.ComponentModel.DataAnnotations;

namespace CreditCar.API.Profiles.Resources;

public class SaveUserResource
{
  [Required]
  public string FirstName { get; set; }
  
  [Required]
  public string LastName { get; set; }
  
  [Required]
  public string Email { get; set; }
  
  [Required]
  public string Password { get; set; }
  
  [Required]
  public int Dni { get; set; }
  
  [Required]
  public int ZipCode { get; set; }
}