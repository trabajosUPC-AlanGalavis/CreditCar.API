using CreditCar.API.Profiles.Domain.Models;
using CreditCar.API.Profiles.Domain.Services.Communication;

namespace CreditCar.API.Profiles.Domain.Services;

public interface ICustomerService
{
    Task<IEnumerable<Customer>> ListAsync();
    Task<CustomerResponse> SaveAsync(Customer customer);
    Task<CustomerResponse> UpdateAsync(int id, Customer customer);
    Task<CustomerResponse> DeleteAsync(int id);
}