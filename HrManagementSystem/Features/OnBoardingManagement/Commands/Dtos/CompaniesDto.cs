using HrManagementSystem.Common.Entities;
using System.Collections.Generic;

namespace HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos
{
    public record CompaniesDto(string Name,
    string? Email,
    string CountryId,
    string OrganizationId,
     List<BranchesDto>? Branches = null);
}
