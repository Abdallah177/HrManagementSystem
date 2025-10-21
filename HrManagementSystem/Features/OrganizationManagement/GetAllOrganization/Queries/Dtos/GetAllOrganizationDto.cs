namespace HrManagementSystem.Features.OrganizationManagement.GetAllOrganization.Queries.Dtos
{
    public class GetAllOrganizationDto
    {
        public string OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public List<GetCompaniesDto> Companies { get; set; } = new List<GetCompaniesDto>();
        public List<GetBranchesDto> Branches { get; set; } = new List<GetBranchesDto>();
        public List<GetDepartmentsDto> Departments { get; set; } = new List<GetDepartmentsDto>();
        public List<GetTeamsDto> Teams { get; set; } = new List<GetTeamsDto>();
    }

}
