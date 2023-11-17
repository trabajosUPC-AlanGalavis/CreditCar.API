using CreditCar.API.Profiles.Domain.Models;
using CreditCar.API.Shared.Domain.Services.Communication;

namespace CreditCar.API.Profiles.Domain.Services.Communication;

public class UserResponse : BaseResponse<User>
{
    public UserResponse(string message) : base(message)
    {
    }

    public UserResponse(User resource) : base(resource)
    {
    }
}