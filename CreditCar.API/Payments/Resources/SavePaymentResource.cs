using System.ComponentModel.DataAnnotations;

namespace CreditCar.API.Payments.Resources;

public class SavePaymentResource
{
  [Required]
  public string Currency { get; set; }
  [Required]
  public string SelectedRate { get; set; }
  [Required]
  public string SelectedPeriod { get; set; }
  [Required]
  public string RateType { get; set; }
  [Required]
  public float RateValue { get; set; }
  [Required]
  public string ClosingDate { get; set; }
  [Required]
  public int TotalGracePeriod { get; set; }
  [Required]
  public int PartialGracePeriod { get; set; }
  [Required]
  public int InitialFee { get; set; }
  [Required]
  public int FinalFee { get; set; }
  [Required]
  public int CreditLifeInsurance { get; set; }
  [Required]
  public int VehicleInsurance { get; set; }
  [Required]
  public DateTime CreateDate { get; set; }
  [Required]
  public float FormattedRateValue { get; set; }
  [Required]
  public float Cok { get; set; }
  [Required]
  public float Van { get; set; }
  [Required]
  public float Tcea { get; set; }
  [Required]
  public float Tir { get; set; }
}