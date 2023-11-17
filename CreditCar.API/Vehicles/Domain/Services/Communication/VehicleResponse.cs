using CreditCar.API.Vehicles.Domain.Models;
using CreditCar.API.Shared.Domain.Services.Communication;

namespace CreditCar.API.Vehicles.Domain.Services.Communication;

public class VehicleResponse : BaseResponse<Vehicle>
{
    public VehicleResponse(string message) : base(message)
    {
    }

    public VehicleResponse(Vehicle resource) : base(resource)
    {
    }
}