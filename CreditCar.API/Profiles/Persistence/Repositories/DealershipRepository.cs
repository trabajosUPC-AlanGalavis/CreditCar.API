using CreditCar.API.Profiles.Domain.Models;
using CreditCar.API.Profiles.Domain.Repositories;
using CreditCar.API.Shared.Persistence.Contexts;
using CreditCar.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CreditCar.API.Profiles.Persistence.Repositories;

public class DealershipRepository : BaseRepository, IDealershipRepository
{
    public DealershipRepository(AppDbContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<Dealership>> ListAsync()
    {
        return await _context.Dealerships.ToListAsync();
    }

    public async Task AddAsync(Dealership dealership)
    {
        await _context.Dealerships.AddAsync(dealership);
    }

    public void Update(Dealership dealership)
    {
        _context.Dealerships.Update(dealership);
    }

    public void Remove(Dealership dealership)
    {
        _context.Dealerships.Remove(dealership);
    }

    public async Task<Dealership> FindByIdAsync(int id)
    {
        return await _context.Dealerships.FindAsync(id);
    }
}