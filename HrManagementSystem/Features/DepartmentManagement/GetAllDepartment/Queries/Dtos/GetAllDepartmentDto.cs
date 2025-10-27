namespace HrManagementSystem.Features.DepartmentManagement.GetAllDepartment.Queries.Dtos
{
    public class GetAllDepartmentDto
    {
        public string DepartmentId { get; set; } = null!;
        public string DepartmentName { get; set; } = null!;
        public string? Description { get; set; }
        public string ? BranchId { get; set; }
        public string? BranchName { get; set; }
        public List<DepartmentTeamDto> Teams { get; set; } = new List<DepartmentTeamDto>();



    }
}
