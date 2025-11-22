using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Branch;

namespace HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Company
{
    public record AddCompaniesHierarchyRequestDto(string Name,
    string? Email,
    string CountryId,
    string OrganizationId,
    List<BranchesDto>? Branches = null);
}
