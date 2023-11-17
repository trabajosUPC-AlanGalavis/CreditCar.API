using System.ComponentModel.DataAnnotations;

namespace CreditCar.API.Vehicles.Resources;

public class SaveVehicleResource
{
  [Required]
  public string Brand { get; set; }
  
  [Required]
  public string Model { get; set; }
  
  [Required]
  public string Image { get; set; }
  
  [Required]
  public int Price { get; set; }
}