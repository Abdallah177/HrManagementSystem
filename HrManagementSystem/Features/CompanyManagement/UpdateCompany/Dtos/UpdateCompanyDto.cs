using HrManagementSystem.Common.Entities.Location;

namespace HrManagementSystem.Features.CompanyManagement.UpdateCompany.Dtos
{
    public record UpdateCompanyDto(string Id, string Name, string Email, string CountryId, string OrganizationId);


}
