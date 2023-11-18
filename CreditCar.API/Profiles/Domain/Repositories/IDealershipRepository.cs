using CreditCar.API.Profiles.Domain.Models;

namespace CreditCar.API.Profiles.Domain.Repositories;

public interface IDealershipRepository
{
    Task<IEnumerable<Dealership>> ListAsync();
    
    Task AddAsync(Dealership customer);
    
    void Update(Dealership customer);
    
    void Remove(Dealership customer);
    
    Task<Dealership> FindByIdAsync(int id);
}