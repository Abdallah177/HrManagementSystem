namespace HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Team
{
    public record AddTeamsHierarchyRequestDto(
     string DepartmentId,
     string DepartmentName,
     string BranchId,
     string CompanyId,
     List<TeamsDto> Teams);
}
