using HrManagementSystem.Common.Entities.Location;

namespace HrManagementSystem.Features.CompanyManagement.Commands.UpdateCompany.Dtos
{
    public record UpdateCompanyDto(string Id, string Name, string Email, string CountryId, string OrganizationId);


}
