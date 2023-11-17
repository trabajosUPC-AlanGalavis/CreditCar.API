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
  [MaxLength(8)]
  public int Dni { get; set; }
  
  [Required]
  [MaxLength(5)]
  public int ZipCode { get; set; }
}