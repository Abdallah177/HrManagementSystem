using HrManagementSystem.Common.Entities;
using HrManagementSystem.Features.Common.Branch.AddBranches.Dtos;
using System.Collections.Generic;

namespace HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Company
{
    public record CompaniesDto(string Name,
    string? Email,
    string CountryId,
    string OrganizationId,
    List<BranchesDto>? Branches = null);
}
