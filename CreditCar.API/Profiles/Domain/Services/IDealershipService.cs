using CreditCar.API.Profiles.Domain.Models;
using CreditCar.API.Profiles.Domain.Services.Communication;

namespace CreditCar.API.Profiles.Domain.Services;

public interface IDealershipService
{
    Task<IEnumerable<Dealership>> ListAsync();
    Task<DealershipResponse> SaveAsync(Dealership dealership);
    Task<DealershipResponse> UpdateAsync(int id, Dealership dealership);
    Task<DealershipResponse> DeleteAsync(int id);
}