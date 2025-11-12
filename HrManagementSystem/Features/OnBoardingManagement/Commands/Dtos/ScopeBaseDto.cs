namespace HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos
{
    public class ScopeBaseDto
    {
        public string OrganizationId {  get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
        public string DepartmentId { get; set; }
        public string? TeamId { get; set; }
    }
}
