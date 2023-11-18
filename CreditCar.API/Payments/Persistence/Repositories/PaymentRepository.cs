using CreditCar.API.Payments.Domain.Models;
using CreditCar.API.Payments.Domain.Repositories;
using CreditCar.API.Shared.Persistence.Contexts;
using CreditCar.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CreditCar.API.Payments.Persistence.Repositories;

public class PaymentRepository : BaseRepository, IPaymentRepository
{
    public PaymentRepository(AppDbContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<Payment>> ListAsync()
    {
        return await _context.Payments.ToListAsync();
    }

    public async Task AddAsync(Payment payment)
    {
        await _context.Payments.AddAsync(payment);
    }

    public void Update(Payment payment)
    {
        _context.Payments.Update(payment);
    }

    public void Remove(Payment payment)
    {
        _context.Payments.Remove(payment);
    }

    public async Task<Payment> FindByIdAsync(int id)
    {
        return await _context.Payments.FindAsync(id);
    }
    
    public async Task<IEnumerable<Payment>> FindByCustomerIdAsync(int customerId)
    {
        return await _context.Payments
            .Where(p => p.CustomerId == customerId)
            .Include(p => p.Customer)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Payment>> FindByVehicleIdAsync(int vehicleId)
    {
        return await _context.Payments
            .Where(p => p.VehicleId == vehicleId)
            .Include(p => p.Customer)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Payment>> FindByDealershipIdAsync(int dealershipId)
    {
        return await _context.Payments
            .Where(p => p.DealershipId == dealershipId)
            .Include(p => p.Customer)
            .ToListAsync();
    }
}