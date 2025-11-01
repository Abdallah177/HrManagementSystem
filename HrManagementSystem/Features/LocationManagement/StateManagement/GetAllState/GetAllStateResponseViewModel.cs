using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Features.BranchManagement.GetAllBranches.DTOs;
using HrManagementSystem.Features.DepartmentManagement.GetAllDepartment.Queries.Dtos;
using HrManagementSystem.Features.LocationManagement.CityManagement.GetAllCities;
using HrManagementSystem.Features.OrganizationManagement.GetOrganization;


namespace HrManagementSystem.Features.LocationManagement.StateManagement.GetAllState
{
    public class GetAllStateResponseViewModel
    {
        public string StateId { get; set; } = null!;
        public string StateName { get; set; } = null!;
        public string CountryId { get; set; } = null!;
        public string CountryName { get; set; } = null!;
        public List<GetAllCitiesResponseViewModel> Cities { get; set; } = new List<GetAllCitiesResponseViewModel>();
        public List<GetBranchesViewModel> Branches { get; set; } = new List<GetBranchesViewModel>();
        public List<GetDepartmentsViewModels> Departments { get; set; } = new List<GetDepartmentsViewModels>();
        public List<GetTeamsViewModels> Teams { get; set; } = new List<GetTeamsViewModels>();
    }
}
