using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Features.BranchManagement.GetAllBranches.DTOs;
using HrManagementSystem.Features.DepartmentManagement.GetAllDepartment.Queries.Dtos;
using HrManagementSystem.Features.LocationManagement.CityManagement.GetAllCities;
using HrManagementSystem.Features.LocationManagement.CityManagement.GetAllCities.Queries.Dtos;
using HrManagementSystem.Features.LocationManagement.StateManagement.GetAllState.Query.DTOS;
using HrManagementSystem.Features.OrganizationManagement.GetOrganization;
using HrManagementSystem.Features.TeamManagement.GetAllTeams.DTOs;
using Mapster;

namespace HrManagementSystem.Features.LocationManagement.StateManagement.GetAllState.Mapping
{
    public class GetAllStateMappingProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // Map from State entity to GetAllStateDTO
            config.NewConfig<State, GetAllStateDTO>()
                .Map(dest => dest.StateId, src => src.Id)
                .Map(dest => dest.StateName, src => src.Name)
                .Map(dest => dest.CountryId, src => src.CountryId)
                .Map(dest => dest.CountryName, src => src.Country.Name)
                .Map(dest => dest.cities, src => src.Cities.Where(c => !c.IsDeleted && c.IsActive));

            // Map from City entity to GetCitiesDto
            config.NewConfig<City, GetCitiesDto>()
                .Map(dest => dest.CityId, src => src.Id)
                .Map(dest => dest.CityName, src => src.Name);
        }
    }
    
}
