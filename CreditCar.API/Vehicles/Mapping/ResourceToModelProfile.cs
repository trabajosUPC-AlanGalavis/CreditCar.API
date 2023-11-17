using AutoMapper;
using CreditCar.API.Vehicles.Domain.Models;
using CreditCar.API.Vehicles.Resources;

namespace CreditCar.API.Vehicles.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveVehicleResource, Vehicle>();
    }
}