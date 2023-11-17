using CreditCar.API.Vehicles.Domain.Repositories;
using CreditCar.API.Vehicles.Domain.Services;
using CreditCar.API.Vehicles.Domain.Services.Communication;
using CreditCar.API.Shared.Domain.Repositories;
using CreditCar.API.Vehicles.Domain.Models;

namespace CreditCar.API.Vehicles.Services;

public class VehicleService : IVehicleService
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public VehicleService(IVehicleRepository vehicleRepository, IUnitOfWork unitOfWork)
    {
        _vehicleRepository = vehicleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Vehicle>> ListAsync()
    {
        return await _vehicleRepository.ListAsync();
    }

    public async Task<VehicleResponse> SaveAsync(Vehicle vehicle)
    {
        try
        {
            await _vehicleRepository.AddAsync(vehicle);
            await _unitOfWork.CompleteAsync();
            return new VehicleResponse(vehicle);
        }
        catch(Exception e)
        {
            return new VehicleResponse($"An error occurred while saving the vehicle: {e.Message}");
        }
    }

    public async Task<VehicleResponse> UpdateAsync(int id, Domain.Models.Vehicle vehicle)
    {
        var existingVehicle = await _vehicleRepository.FindByIdAsync(id);
        
        if (existingVehicle == null)
            return new VehicleResponse("Vehicle not found.");
        
        existingVehicle.Brand = vehicle.Brand;
        existingVehicle.Model = vehicle.Model;
        existingVehicle.Image = vehicle.Image;
        existingVehicle.Price = vehicle.Price;

        try
        {
            _vehicleRepository.Update(existingVehicle);
            await _unitOfWork.CompleteAsync();
            return new VehicleResponse(existingVehicle);
        }
        catch (Exception e)
        {
            return new VehicleResponse($"An error occurred while updating the vehicle: {e.Message}");
        }
    }

    public async Task<VehicleResponse> DeleteAsync(int id)
    {
        var existingVehicle = await _vehicleRepository.FindByIdAsync(id);
        
        if (existingVehicle == null)
            return new VehicleResponse("Vehicle not found.");
        
        try
        {
            _vehicleRepository.Remove(existingVehicle);
            await _unitOfWork.CompleteAsync();
            return new VehicleResponse(existingVehicle);
        }
        catch (Exception e)
        {
            return new VehicleResponse($"An error occurred while deleting the vehicle: {e.Message}");
        }
    }
}