namespace HrManagementSystem.Features.OrganizationManagement.GetByIDOrganization.DTOs
{
    public record GetCompniesByOrganizationIDDto(string CompanyId, string CompanyName, List<GetBranchesByCompanyIDDto> Branches);
    
}
