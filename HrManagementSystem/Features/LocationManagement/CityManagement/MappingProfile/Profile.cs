using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Features.LocationManagement.CityManagement.GetAllCities.Queries.Dtos;
using HrManagementSystem.Features.LocationManagement.CityManagement.GetByIDCity.DTOs;
using Mapster;

namespace HrManagementSystem.Features.LocationManagement.CityManagement.MappingProfile
{
    public class Profile :IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            TypeAdapterConfig<City, CityResponseDto>
            .NewConfig()
            .Map(dest => dest.CityId, src => src.Id)
            .Map(dest => dest.CityName, src => src.Name)
            .Map(dest => dest.StateId, src => src.StateId)
            .Map(dest => dest.StateName, src => src.State.Name)
            .Map(dest => dest.CountryName, src => src.State.Country.Name)
            .Map(dest => dest.IsActive, src => src.IsActive);



        }
    }
}
