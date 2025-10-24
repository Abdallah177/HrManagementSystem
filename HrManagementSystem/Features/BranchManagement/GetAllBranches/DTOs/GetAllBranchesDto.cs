namespace HrManagementSystem.Features.BranchManagement.GetAllBranches.DTOs
{
    public record GetAllBranchesDto(
        string BranchId, 
        string BranchName, 
        string CompanyId, 
        string CompanyName, 
        string CityId, 
        string CityName);

}
