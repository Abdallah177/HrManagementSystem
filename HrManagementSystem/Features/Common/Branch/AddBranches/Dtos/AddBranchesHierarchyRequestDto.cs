namespace HrManagementSystem.Features.Common.Branch.AddBranches.Dtos
{
    public record AddBranchesHierarchyRequestDto(
     string CompanyId ,
     string CompanyName ,
     string DefaultCityId ,
     List<BranchesDto> Branches);
}
