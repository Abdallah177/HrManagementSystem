using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos;

namespace HrManagementSystem.Features.Common.Branch.AddBranches.Dtos
{
    public record AddBranchesRequestDto(string CompanyId , string CompanyName , string DefaultCityId , List<BranchesDto> Branches);
}
