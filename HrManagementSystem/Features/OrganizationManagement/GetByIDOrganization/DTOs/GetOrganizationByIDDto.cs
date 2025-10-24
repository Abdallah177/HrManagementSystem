namespace HrManagementSystem.Features.OrganizationManagement.GetByIDOrganization.DTOs
{
    public record GetOrganizationByIDDto(string OrganizationId, string OrganizationName, List<GetCompniesByOrganizationIDDto> Companies);
    
}
