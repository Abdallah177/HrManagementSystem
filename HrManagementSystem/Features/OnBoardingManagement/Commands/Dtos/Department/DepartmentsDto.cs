using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Team;

namespace HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Department
{
    public record DepartmentsDto(
        string Name,
        string? Description,
        string BranchId,
        List<TeamsDto>? Teams = null
    );
}
