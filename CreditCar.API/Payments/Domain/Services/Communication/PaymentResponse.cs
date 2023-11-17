using CreditCar.API.Payments.Domain.Models;
using CreditCar.API.Shared.Domain.Services.Communication;

namespace CreditCar.API.Payments.Domain.Services.Communication;

public class PaymentResponse : BaseResponse<Payment>
{
    public PaymentResponse(string message) : base(message)
    {
    }

    public PaymentResponse(Payment resource) : base(resource)
    {
    }
}