namespace HrManagementSystem.Features.OrganizationManagement.GetByIDOrganization.DTOs
{
    public record GetBranchesByCompanyIDDto(string BranchId, string BranchName, List<GetDepartmentsByBranchIDDto> Departments);

}
