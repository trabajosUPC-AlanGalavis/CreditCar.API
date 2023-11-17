using CreditCar.API.Profiles.Domain.Models;

namespace CreditCar.API.Profiles.Domain.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> ListAsync();
    
    Task AddAsync(User user);
    
    void Update(User user);
    
    void Remove(User user);
    
    Task<User> FindByIdAsync(int id);
    
    Task<User> FindByEmailAsync(string name);
    
    Task<User> FindByDniAsync(int dni);
}