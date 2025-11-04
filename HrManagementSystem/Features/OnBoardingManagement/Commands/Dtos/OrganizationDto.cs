using HrManagementSystem.Features.CompanyManagement.GetAllCompany.Dto;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Company;

namespace HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos
{
    public class OrganizationDto
    {
        public string Name {  get; set; }
        public List<CompaniesDto> Companies { get; set; }
    }
}
