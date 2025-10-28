namespace HrManagementSystem.Features.BranchManagement.UpdateBranch
{
    public record UpdateBranchResponseViewModel(
        string Id,
        string Name,
        string? Phone,
        string CompanyId,
        string CityId

    );
    
}
