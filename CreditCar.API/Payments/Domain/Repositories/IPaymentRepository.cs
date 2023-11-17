using CreditCar.API.Payments.Domain.Models;

namespace CreditCar.API.Payments.Domain.Repositories;

public interface IPaymentRepository
{
    Task<IEnumerable<Payment>> ListAsync();
    
    Task AddAsync(Payment payment);
    
    void Update(Payment payment);
    
    void Remove(Payment payment);
    
    Task<Payment> FindByIdAsync(int id);
}