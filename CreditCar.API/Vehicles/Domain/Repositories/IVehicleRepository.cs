using CreditCar.API.Vehicles.Domain.Models;

namespace CreditCar.API.Vehicles.Domain.Repositories;

public interface IVehicleRepository
{
    Task<IEnumerable<Vehicle>> ListAsync();
    
    Task AddAsync(Vehicle vehicle);
    
    void Update(Vehicle vehicle);
    
    void Remove(Vehicle vehicle);
    
    Task<Vehicle> FindByIdAsync(int id);
}