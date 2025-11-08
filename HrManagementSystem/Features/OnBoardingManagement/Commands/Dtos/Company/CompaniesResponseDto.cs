using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Branch;

namespace HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Company
{
    public class CompaniesResponseDto
    {
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string DefaultCity { get; set; }
        public List<BranchesDto> Branches { get; set; }
    }
}
