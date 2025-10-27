using HrManagementSystem.Features.DepartmentManagement.GetAllDepartment.Queries.Dtos;

namespace HrManagementSystem.Features.DepartmentManagement.GetAllDepartment
{
    public class GetAllDepartmentResponseViewModel
    {
        public string DepartmentId { get; set; } = null!;
        public string DepartmentName { get; set; } = null!;
        public string? Description { get; set; }
        public string? BranchId { get; set; }
        public string? BranchName { get; set; }
        public List<DepartmentTeamDto> Teams { get; set; } = new List<DepartmentTeamDto>();
    }

    public class DepartmentTeamResponseViewModel
    {
        public string TeamId { get; set; } = null!;
        public string TeamName { get; set; } = null!;
    }
}
