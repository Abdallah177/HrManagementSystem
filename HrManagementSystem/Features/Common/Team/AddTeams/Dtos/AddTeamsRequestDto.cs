using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos;

namespace HrManagementSystem.Features.Common.Team.AddTeams.Dtos
{
    public record AddTeamsRequestDto(string DepartmentId, string DepartmentName, string BranchId, string CompanyId, List<TeamsDto> Teams);
}
