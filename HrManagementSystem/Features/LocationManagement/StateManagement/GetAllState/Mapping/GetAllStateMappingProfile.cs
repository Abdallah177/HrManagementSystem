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

            config.NewConfig<GetAllStateDTO, GetAllStateResponseViewModel>()
                  .MaxDepth(3);
            config.NewConfig<CityResponseDto, GetAllCitiesResponseViewModel>()
                  .TwoWays(); 
            config.NewConfig<GetAllBranchesDto, GetBranchesViewModel>()
                  .TwoWays();
            config.NewConfig<GetAllDepartmentDto, GetDepartmentsViewModels>()
                  .TwoWays();
            config.NewConfig<GetAllTeamsDto, GetTeamsViewModels>()
                  .TwoWays();
        }
    }
}
