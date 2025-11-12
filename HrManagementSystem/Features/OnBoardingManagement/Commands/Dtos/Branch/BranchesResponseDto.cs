using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Department;

namespace HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Branch
{
    public class BranchesResponseDto
    {
        public string BranchId { get; set; }
        public string BranchName { get; set; }
        public string CompanyId { get; set; }
        public List<DepartmentsDto> Departments { get; set; }
    }
}
