using CreditCar.API.Profiles.Domain.Models;

namespace CreditCar.API.Profiles.Domain.Repositories;

public interface ICustomerRepository
{
    Task<IEnumerable<Customer>> ListAsync();
    
    Task AddAsync(Customer customer);
    
    void Update(Customer customer);
    
    void Remove(Customer customer);
    
    Task<Customer> FindByIdAsync(int id);
}