using HrManagementSystem.Features.Common.Team.AddTeams.Dtos;

namespace HrManagementSystem.Features.Common.Department.AddDepartments.Dtos
{
    public record DepartmentsDto(
        string Name,
        string? Description,
        string BranchId,
        List<TeamsDto>? Teams = null
    );
}
