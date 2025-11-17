namespace HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos
{
    public record DepartmentsDto(
        string Name,
        string? Description,
        string BranchId,
        List<TeamsDto>? Teams = null
    );
}
