using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos;

namespace HrManagementSystem.Features.Common.Branch.AddBranches.Dtos
{
    public class BranchesResponseDto
    {
        public string BranchId { get; set; }
        public string BranchName { get; set; }
        public string CompanyId { get; set; }
        public List<DepartmentsDto> Departments { get; set; }
    }
}
