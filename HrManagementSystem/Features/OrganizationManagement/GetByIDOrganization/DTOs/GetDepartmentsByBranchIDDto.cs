namespace HrManagementSystem.Features.OrganizationManagement.GetByIDOrganization.DTOs
{
    public record GetDepartmentsByBranchIDDto(string DepartmentId, string DepartmentName, List<GetTeamsByDepartmentIDDto> Teams);
    
}
