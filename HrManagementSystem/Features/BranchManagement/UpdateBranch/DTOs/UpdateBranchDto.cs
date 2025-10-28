using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Entities.Location;

namespace HrManagementSystem.Features.BranchManagement.UpdateBranch.DTOs
{
    public record UpdateBranchDto(
        string Id,
        string Name,
        string? Phone,
        string CompanyId,
        string CityId
        
    );
}

