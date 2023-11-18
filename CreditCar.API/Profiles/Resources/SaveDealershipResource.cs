using System.ComponentModel.DataAnnotations;

namespace CreditCar.API.Profiles.Resources;

public class SaveDealershipResource
{
  [Required]
  public string Name { get; set; }
}