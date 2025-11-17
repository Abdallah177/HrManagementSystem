namespace HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Branch
{
    public record AddBranchesHierarchyRequestDto(
     string CompanyId ,
     string CompanyName ,
     string DefaultCityId ,
     List<BranchesDto> Branches);
}
