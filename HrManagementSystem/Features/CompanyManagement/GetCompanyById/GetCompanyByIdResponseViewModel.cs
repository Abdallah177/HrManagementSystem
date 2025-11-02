namespace HrManagementSystem.Features.CompanyManagement.GetCompanyById
{
    public class GetCompanyByIdResponseViewModel
    {
        
            public string Id { get; set; }
            public string Name { get; set; } = null!;
            public string? Email { get; set; }
            public string CountryId { get; set; }
            public string OrganizationId { get; set; }

    }
}
