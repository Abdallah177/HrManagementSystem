using HrManagementSystem.Features.Common.Department.AddDepartments.Dtos;

namespace HrManagementSystem.Features.Common.Branch.AddBranches.Dtos
{
    public record BranchesDto(
         string Name,
         string? Phone,
         string CityId,
         string CompanyId,
         List<DepartmentsDto>? Departments = null
     );
}
