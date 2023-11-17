using AutoMapper;
using CreditCar.API.Profiles.Domain.Models;
using CreditCar.API.Profiles.Resources;

namespace CreditCar.API.Profiles.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveUserResource, User>();
    }
}