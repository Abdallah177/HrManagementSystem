namespace HrManagementSystem.Features.OnBoardingManagement
{
    public record OnBoardingRequestViewModel(OrganizationRequestViewModel Organization);

    public record OrganizationRequestViewModel(
            string Name,
            List<CompanyRequestViewModel> Companies
      );

    public record CompanyRequestViewModel(
        string Name,
        string? Email,
        string CountryId,
        List<BranchRequestViewModel>? Branches = null
    );

    public record BranchRequestViewModel(
        string Name,
        string? Phone,
        string CityId,
        List<DepartmentRequestViewModel>? Departments = null
    );

    public record DepartmentRequestViewModel(
        string Name,
        string? Description,
        List<TeamRequestViewModel>? Teams = null
    );

    public record TeamRequestViewModel(string Name);
}

