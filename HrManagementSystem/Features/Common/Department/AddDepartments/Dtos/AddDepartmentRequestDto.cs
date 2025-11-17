using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos;

namespace HrManagementSystem.Features.Common.Department.AddDepartments.Dtos
{
    public record AddDepartmentRequestDto( string BranchId , string BranchName , string CompanyId ,List<DepartmentsDto> Departments);
}
