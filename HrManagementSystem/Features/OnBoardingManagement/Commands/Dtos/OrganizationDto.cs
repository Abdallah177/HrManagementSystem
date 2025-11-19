using HrManagementSystem.Features.CompanyManagement.GetAllCompany.Dto;

namespace HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos
{
    public record OrganizationDto(string Name, List<CompaniesDto> Companies);
}
