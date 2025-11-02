namespace HrManagementSystem.Features.OrganizationManagement.GetOrganization.Queries.Dtos
{
    public class GetOrganizationDto
    {
        public string OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public List<GetCompaniesDto> Companies { get; set; } = new List<GetCompaniesDto>();
    }

}
