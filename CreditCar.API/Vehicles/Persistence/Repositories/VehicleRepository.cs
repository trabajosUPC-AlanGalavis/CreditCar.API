using CreditCar.API.Vehicles.Domain.Models;
using CreditCar.API.Vehicles.Domain.Repositories;
using CreditCar.API.Shared.Persistence.Contexts;
using CreditCar.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CreditCar.API.Vehicles.Persistence.Repositories;

public class VehicleRepository : BaseRepository, IVehicleRepository
{
    public VehicleRepository(AppDbContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<Vehicle>> ListAsync()
    {
        return await _context.Vehicles.ToListAsync();
    }

    public async Task AddAsync(Vehicle vehicle)
    {
        await _context.Vehicles.AddAsync(vehicle);
    }

    public void Update(Vehicle vehicle)
    {
        _context.Vehicles.Update(vehicle);
    }

    public void Remove(Vehicle vehicle)
    {
        _context.Vehicles.Remove(vehicle);
    }

    public async Task<Vehicle> FindByIdAsync(int id)
    {
        return await _context.Vehicles.FindAsync(id);
    }
}