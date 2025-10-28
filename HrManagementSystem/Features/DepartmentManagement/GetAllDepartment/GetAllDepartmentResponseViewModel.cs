using HrManagementSystem.Features.DepartmentManagement.GetAllDepartment.Queries.Dtos;

namespace HrManagementSystem.Features.DepartmentManagement.GetAllDepartment
{
    public class GetAllDepartmentResponseViewModel
    {
        public string DepartmentId { get; set; } 
        public string DepartmentName { get; set; }
        public string Description { get; set; }
        public string BranchId { get; set; }
        public string BranchName { get; set; }
        public List<DepartmentTeamResponseViewModel> Teams { get; set; } = new List<DepartmentTeamResponseViewModel>();
    }

    public class DepartmentTeamResponseViewModel
    {
        public string TeamId { get; set; } = null!;
        public string TeamName { get; set; } = null!;
    }
}
