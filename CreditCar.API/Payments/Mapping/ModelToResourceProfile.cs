using AutoMapper;
using CreditCar.API.Payments.Domain.Models;
using CreditCar.API.Payments.Resources;

namespace CreditCar.API.Payments.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Payment, PaymentResource>();
    }
}