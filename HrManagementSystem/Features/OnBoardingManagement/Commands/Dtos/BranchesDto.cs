namespace HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos
{
    public record BranchesDto(
         string Name,
         string? Phone,
         string CityId,
         string CompanyId,
         List<DepartmentsDto>? Departments = null
     );
}
