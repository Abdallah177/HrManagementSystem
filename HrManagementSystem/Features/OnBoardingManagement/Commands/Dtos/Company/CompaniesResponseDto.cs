namespace HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Company
{
    public class CompaniesResponseDto
    {
        public string companyId { get; set; }
        public List<BranchesDto> branches { get; set; }
    }
}
