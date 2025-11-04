using HrManagementSystem.Features.CompanyManagement.GetAllCompany.Dto;

namespace HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos
{
    public class OrganizationDto
    {
        public string Name {  get; set; }
        public List<CompanyDto> companies { get; set; }
    }
}
