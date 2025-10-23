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
                .Map(dest => dest.StateName, src => src.State != null ? src.State.Name : null)
                .Map(dest => dest.CountryName, src => src.State != null && src.State.Country != null ? src.State.Country.Name : null)
                .Map(dest => dest.IsActive, src => src.IsActive);
        }
    }
}
