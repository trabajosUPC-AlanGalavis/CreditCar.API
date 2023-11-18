using CreditCar.API.Payments.Domain.Models;

namespace CreditCar.API.Payments.Domain.Repositories;

public interface IPaymentRepository
{
    Task<IEnumerable<Payment>> ListAsync();
    
    Task AddAsync(Payment payment);
    
    void Update(Payment payment);
    
    void Remove(Payment payment);
    
    Task<Payment> FindByIdAsync(int id);
    
    Task<IEnumerable<Payment>> FindByCustomerIdAsync(int customerId);
    
    Task<IEnumerable<Payment>> FindByDealershipIdAsync(int dealershipId);
    
    Task<IEnumerable<Payment>> FindByVehicleIdAsync(int vehicleId);
}