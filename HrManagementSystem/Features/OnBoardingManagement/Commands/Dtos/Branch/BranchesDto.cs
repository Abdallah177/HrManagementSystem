using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Department;

namespace HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Branch
{
    public record BranchesDto(
         string Name,
         string? Phone,
         string CityId,
         string CompanyId,
         List<DepartmentsDto>? Departments = null
     );
}
