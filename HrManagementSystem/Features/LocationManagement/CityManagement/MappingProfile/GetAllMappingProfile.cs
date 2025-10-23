using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Features.LocationManagement.CityManagement.GetByIDCity.DTOs;
using Mapster;

namespace HrManagementSystem.Features.LocationManagement.CityManagement.MappingProfile
{
    public class GetAllMappingProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            TypeAdapterConfig<City, CityDTOs>
             .NewConfig()
               
               .Map(dest => dest.CityName, src => src.Name) 
               .Map(dest => dest.StateName, src => src.State.Name)
               .Map(dest => dest.CountryName, src => src.State.Country.Name)
               .Map(dest => dest.IsActive, src => src.IsActive);
        }
    }
}
