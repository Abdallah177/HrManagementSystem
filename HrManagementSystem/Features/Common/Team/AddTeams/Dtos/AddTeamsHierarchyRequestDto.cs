namespace HrManagementSystem.Features.Common.Team.AddTeams.Dtos
{
    public record AddTeamsHierarchyRequestDto(
     string DepartmentId,
     string DepartmentName,
     string BranchId,
     string CompanyId,
     List<TeamsDto> Teams);
}
