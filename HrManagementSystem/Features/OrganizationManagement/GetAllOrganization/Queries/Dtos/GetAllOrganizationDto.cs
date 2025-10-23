namespace HrManagementSystem.Features.OrganizationManagement.GetAllOrganization.Queries.Dtos
{
    public class GetAllOrganizationDto
    {
        public string OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public List<GetCompaniesDto> Companies { get; set; } = new List<GetCompaniesDto>();
    }

}
