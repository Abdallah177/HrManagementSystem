namespace HrManagementSystem.Features.OrganizationManagement.GetOrganization.Queries.Dtos
{
    public class GetBranchesDto
    {
        public string BranchId { get; set; }
        public string BranchName { get; set; }
        public string? BranchPhone { get; set; }
        public string CityId { get; set; }
        public string CityName { get; set; }

        public List<GetDepartmentsDto> Departments { get; set; } = new List<GetDepartmentsDto>();
    }
}
