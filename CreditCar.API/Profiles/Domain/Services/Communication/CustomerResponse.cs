using CreditCar.API.Profiles.Domain.Models;
using CreditCar.API.Shared.Domain.Services.Communication;

namespace CreditCar.API.Profiles.Domain.Services.Communication;

public class CustomerResponse : BaseResponse<Customer>
{
    public CustomerResponse(string message) : base(message)
    {
    }

    public CustomerResponse(Customer resource) : base(resource)
    {
    }
}