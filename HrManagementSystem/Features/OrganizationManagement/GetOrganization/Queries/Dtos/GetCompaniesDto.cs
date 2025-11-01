namespace HrManagementSystem.Features.OrganizationManagement.GetOrganization.Queries.Dtos
{
    public class GetCompaniesDto
    {
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string? CompanyEmail { get; set; }
        public string CountryId { get; set; }
        public string CountryName { get; set; }
        public List<GetBranchesDto> Branches { get; set; } = new List<GetBranchesDto>();
    }
}
