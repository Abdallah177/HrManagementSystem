namespace HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Team
{
    public class TeamWithScopesDto
    {
        public TeamsDto Team { get; set; }
        public string BranchId {  get; set; }   
        public string CompanyId {  get; set; }
    }
}
