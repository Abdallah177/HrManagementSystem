namespace HrManagementSystem.Features.Common.Department.AddDepartments.Dtos
{
    public record AddDepartmentsHierarchyRequestDto(
     string BranchId ,
     string BranchName ,
     string CompanyId ,
     List<DepartmentsDto> Departments);
}
