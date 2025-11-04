using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Features.LocationManagement.StateManagement.GetStateById.Queries.Dto;
using Mapster;

namespace HrManagementSystem.Features.LocationManagement.StateManagement.GetStateById.MappingProfile
{
    public class Profile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
           
            config.NewConfig<State, GetByIdStateDto>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Country, src => src.Country)
                .Map(dest => dest.Cities, src => src.Cities.Where(c => !c.IsDeleted && c.IsActive));

            config.NewConfig<Country, GetCountryDto>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name);

            config.NewConfig<City, GetCityDto>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name);
        }
    }
}
