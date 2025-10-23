namespace HrManagementSystem.Features.OrganizationManagement.GetAllOrganization.Queries.Dtos
{
    public class GetDepartmentsDto
    {

        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public List<GetTeamsDto> Teams { get; set; } = new List<GetTeamsDto>();
    }
}
