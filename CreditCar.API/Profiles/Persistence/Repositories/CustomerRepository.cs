using CreditCar.API.Profiles.Domain.Models;
using CreditCar.API.Profiles.Domain.Repositories;
using CreditCar.API.Shared.Persistence.Contexts;
using CreditCar.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CreditCar.API.Profiles.Persistence.Repositories;

public class CustomerRepository : BaseRepository, ICustomerRepository
{
    public CustomerRepository(AppDbContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<Customer>> ListAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task AddAsync(Customer customer)
    {
        await _context.Users.AddAsync(customer);
    }

    public void Update(Customer customer)
    {
        _context.Users.Update(customer);
    }

    public void Remove(Customer customer)
    {
        _context.Users.Remove(customer);
    }

    public async Task<Customer> FindByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }
}