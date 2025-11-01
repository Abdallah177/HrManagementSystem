namespace HrManagementSystem.Features.OrganizationManagement.GetOrganization.Queries.Dtos
{
    public class GetDepartmentsDto
    {

        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public string? DepartmentDescription { get; set; }
        public List<GetTeamsDto> Teams { get; set; } = new List<GetTeamsDto>();
    }
}
