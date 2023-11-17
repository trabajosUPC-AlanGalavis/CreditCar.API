using CreditCar.API.Vehicles.Domain.Models;
using CreditCar.API.Vehicles.Domain.Services.Communication;

namespace CreditCar.API.Vehicles.Domain.Services;

public interface IVehicleService
{
    Task<IEnumerable<Vehicle>> ListAsync();
    Task<VehicleResponse> SaveAsync(Vehicle vehicle);
    Task<VehicleResponse> UpdateAsync(int id, Vehicle vehicle);
    Task<VehicleResponse> DeleteAsync(int id);
}