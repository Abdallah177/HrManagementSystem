using HrManagementSystem.Features.OrganizationManagement.GetByIDOrganization.DTOs;

namespace HrManagementSystem.Features.OrganizationManagement.GetByIDOrganization
{
    public record GetOrganizationByIDResponseViewModel(string OrganizationId, string OrganizationName, List<GetCompniesByOrganizationIDDto> Companies);
    public record GetCompniesByOrganizationIDResponseViewModel(string CompanyId, string CompanyName, List<GetBranchesByCompanyIDDto> Branches);
    public record GetBranchesByCompanyIDResponseViewModel(string BranchId, string BranchName, List<GetDepartmentsByBranchIDDto> Departments);
    public record GetDepartmentsByBranchIDResponseViewModel(string DepartmentId, string DepartmentName, List<GetTeamsByDepartmentIDDto> Teams);
    public record GetTeamsByDepartmentIDResponseViewModel(string TeamId, string TeamName);

}
