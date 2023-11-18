using CreditCar.API.Profiles.Domain.Models;
using CreditCar.API.Shared.Domain.Services.Communication;

namespace CreditCar.API.Profiles.Domain.Services.Communication;

public class DealershipResponse : BaseResponse<Dealership>
{
    public DealershipResponse(string message) : base(message)
    {
    }

    public DealershipResponse(Dealership resource) : base(resource)
    {
    }
}