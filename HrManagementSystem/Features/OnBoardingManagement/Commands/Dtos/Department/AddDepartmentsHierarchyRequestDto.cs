namespace HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Department
{
    public record AddDepartmentsHierarchyRequestDto(
     string BranchId ,
     string BranchName ,
     string CompanyId ,
     List<DepartmentsDto> Departments);
}
