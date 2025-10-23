namespace HrManagementSystem.Features.OrganizationManagement.GetAllOrganization.Queries.Dtos
{
    public class GetCompaniesDto
    {
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public List<GetBranchesDto> Branches { get; set; } = new List<GetBranchesDto>();
    }
}
