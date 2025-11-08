using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Team;

namespace HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Department
{
    public class DepartmentsResponseDto
    {
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public List<TeamsDto> Teams { get; set; }
    }
}
