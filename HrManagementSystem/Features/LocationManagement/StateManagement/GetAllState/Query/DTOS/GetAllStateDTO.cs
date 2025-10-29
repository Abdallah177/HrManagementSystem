using HrManagementSystem.Features.BranchManagement.GetAllBranches.DTOs;
using HrManagementSystem.Features.BranchManagement.GetBranchById.Queries.Dtos;
using HrManagementSystem.Features.DepartmentManagement.GetAllDepartment.Queries.Dtos;
using HrManagementSystem.Features.LocationManagement.CityManagement.GetAllCities.Queries.Dtos;
using HrManagementSystem.Features.TeamManagement.GetAllTeams.DTOs;

namespace HrManagementSystem.Features.LocationManagement.StateManagement.GetAllState.Query.DTOS
{
    public class GetAllStateDTO
    {
        public string StateId { get; set; } = null!;
        public string StateName { get; set; } = null!;
        public string CountryId { get; set; } = null!;
        public string CountryName { get; set; } = null!;
        public List<CityResponseDto> Cities { get; set; } = new List<CityResponseDto>();
        public List<GetAllBranchesDto> Branches { get; set; } = new List<GetAllBranchesDto>();  
        public List<GetAllDepartmentDto> Departments { get; set; } = new List<GetAllDepartmentDto>();   
        public List<GetAllTeamsDto> Teams { get; set; } = new List<GetAllTeamsDto>();
    }

}
