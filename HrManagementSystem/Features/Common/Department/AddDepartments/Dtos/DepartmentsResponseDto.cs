

using HrManagementSystem.Features.Common.Team.AddTeams.Dtos;

namespace HrManagementSystem.Features.Common.Department.AddDepartments.Dtos
{
    public class DepartmentsResponseDto
    {
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; } //for a default value
        public string BranchId { get; set; }   
        public string CompanyId { get; set; }
        public List<TeamsDto> Teams { get; set; }
    }
}
