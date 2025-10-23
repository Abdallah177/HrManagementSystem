using HrManagementSystem.Common.Entities.Location;
using Mapster;

namespace HrManagementSystem.Features.LocationManagement.CountryManagement.GetAllCountries
{
    public class CountryMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Country, GetAllCountriesViewModel>()
                  .Map(dest => dest.Name, src => src.Name)
                  .Map(dest => dest.Code, src => src.Code);
        }
    }
}
