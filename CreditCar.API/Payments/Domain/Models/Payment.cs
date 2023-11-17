namespace CreditCar.API.Payments.Domain.Models;

public class Payment
{
    public int Id { get; set; }
    public string Currency { get; set; }
    public string SelectedRate { get; set; }
    public string SelectedPeriod { get; set; }
    public string RateType { get; set; }
    public float RateValue { get; set; }
    public string ClosingDate { get; set; }
    public int TotalGracePeriod { get; set; }
    public int PartialGracePeriod { get; set; }
    public int InitialFee { get; set; }
    public int FinalFee { get; set; }
    public int CreditLifeInsurance { get; set; }
    public int VehicleInsurance { get; set; }
    public DateTime CreateDate { get; set; }
    public float FormattedRateValue { get; set; }
    public float Cok { get; set; }
    public float Van { get; set; }
    public float Tcea { get; set; }
    public float Tir { get; set; }
   
    
    // Relationships
    
    //public int PlanId { get; set; }
    
    //public IList<Plan> Plans { get; set; } = new List<Plan>();
}