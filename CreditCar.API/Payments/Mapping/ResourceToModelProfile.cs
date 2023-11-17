using AutoMapper;
using CreditCar.API.Payments.Domain.Models;
using CreditCar.API.Payments.Resources;

namespace CreditCar.API.Payments.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SavePaymentResource, Payment>();
    }
}