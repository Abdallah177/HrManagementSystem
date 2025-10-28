namespace HrManagementSystem.Features.DepartmentManagement.GetAllDepartment.Queries.Dtos
{
    public class GetAllDepartmentDto
    {
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string Description { get; set; }
        public string BranchId { get; set; }
        public string BranchName { get; set; }
        public List<DepartmentTeamDto> Teams { get; set; } = new List<DepartmentTeamDto>();



    }
}
