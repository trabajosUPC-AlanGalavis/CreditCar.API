using AutoMapper;
using CreditCar.API.Profiles.Domain.Models;
using CreditCar.API.Profiles.Resources;

namespace CreditCar.API.Profiles.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<User, UserResource>();
    }
}