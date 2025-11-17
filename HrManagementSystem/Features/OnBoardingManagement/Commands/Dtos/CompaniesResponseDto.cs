namespace HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos
{
    public class CompaniesResponseDto
    {
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string DefaultCityId { get; set; }
        public List<BranchesDto> Branches { get; set; }
    }
}
