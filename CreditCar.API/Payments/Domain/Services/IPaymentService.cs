using CreditCar.API.Payments.Domain.Models;
using CreditCar.API.Payments.Domain.Services.Communication;

namespace CreditCar.API.Payments.Domain.Services;

public interface IPaymentService
{
    Task<IEnumerable<Payment>> ListAsync();
    Task<PaymentResponse> SaveAsync(Payment payment);
    Task<PaymentResponse> UpdateAsync(int id, Payment payment);
    Task<PaymentResponse> DeleteAsync(int id);
}