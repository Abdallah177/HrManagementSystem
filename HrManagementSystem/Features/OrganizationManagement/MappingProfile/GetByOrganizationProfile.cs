using HrManagementSystem.Common.Entities;
using HrManagementSystem.Features.OrganizationManagement.GetByIDOrganization.DTOs;
using Mapster;

namespace HrManagementSystem.Features.OrganizationManagement.MappingProfile
{
    public class GetByOrganizationProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // Organization to GetOrganizationByIDDto
            config.NewConfig<Organization, GetOrganizationByIDDto>()
                .Map(dest => dest.OrganizationId, src => src.Id)
                .Map(dest => dest.OrganizationName, src => src.Name)
                .Map(dest => dest.Companies, src => src.Companies
                    .Where(c => !c.IsDeleted && c.IsActive)
                    .OrderBy(c => c.Name));

            // Company to GetCompniesByOrganizationIDDto
            config.NewConfig<Company, GetCompniesByOrganizationIDDto>()
                .Map(dest => dest.CompanyId, src => src.Id)
                .Map(dest => dest.CompanyName, src => src.Name)
                .Map(dest => dest.Branches, src => src.Branches
                    .Where(b => !b.IsDeleted && b.IsActive)
                    .OrderBy(b => b.Name));

            // Branch to GetBranchesByCompanyIDDto
            config.NewConfig<Branch, GetBranchesByCompanyIDDto>()
                .Map(dest => dest.BranchId, src => src.Id)
                .Map(dest => dest.BranchName, src => src.Name)
                .Map(dest => dest.Departments, src => src.Departments
                    .Where(d => !d.IsDeleted && d.IsActive)
                    .OrderBy(d => d.Name));

            // Department to GetDepartmentsByBranchIDDto
            config.NewConfig<Department, GetDepartmentsByBranchIDDto>()
                .Map(dest => dest.DepartmentId, src => src.Id)
                .Map(dest => dest.DepartmentName, src => src.Name)
                .Map(dest => dest.Teams, src => src.Teams
                    .Where(t => !t.IsDeleted && t.IsActive)
                    .OrderBy(t => t.Name));

            // Team to GetTeamsByDepartmentIDDto
            config.NewConfig<Team, GetTeamsByDepartmentIDDto>()
                .Map(dest => dest.TeamId, src => src.Id)
                .Map(dest => dest.TeamName, src => src.Name);

        }
    }
}
