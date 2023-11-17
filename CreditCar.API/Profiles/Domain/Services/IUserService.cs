using CreditCar.API.Profiles.Domain.Models;
using CreditCar.API.Profiles.Domain.Services.Communication;

namespace CreditCar.API.Profiles.Domain.Services;

public interface IUserService
{
    Task<IEnumerable<User>> ListAsync();
    Task<UserResponse> SaveAsync(User user);
    Task<UserResponse> UpdateAsync(int id, User user);
    Task<UserResponse> DeleteAsync(int id);
}