using HrManagementSystem.Features.CompanyManagement.GetAllCompany.Dto;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Company;

namespace HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Organization
{
    public record OrganizationDto(string Name, List<CompaniesDto> Companies);
}
