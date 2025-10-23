namespace HrManagementSystem.Features.BranchManagement.GetAllBranches
{
    public record GetAllBranchesResponseViewModel(
        string BranchId,
        string BranchName,
        string CompanyId,
        string CompanyName,
        string CityId,
        string CityName);
    
    
}
