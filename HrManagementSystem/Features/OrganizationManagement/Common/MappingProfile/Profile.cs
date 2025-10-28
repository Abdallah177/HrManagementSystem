using HrManagementSystem.Common.Entities;
using HrManagementSystem.Features.BranchManagement.GetBranchById.Queries.Dtos;
using HrManagementSystem.Features.OrganizationManagement.GetAllOrganization.Queries.Dtos;
using Mapster;

namespace HrManagementSystem.Features.OrganizationManagement.Common.MappingProfile
{
    public class Profile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // Organization to GetAllOrganizationDto
            config.NewConfig<Organization, GetAllOrganizationDto>()
              .Map(dest => dest.OrganizationId, src => src.Id)
                .Map(dest => dest.OrganizationName, src => src.Name)
                .Map(dest => dest.Companies, src => src.Companies
                    .Where(c => !c.IsDeleted && c.IsActive)
                    .OrderBy(c => c.Name));

            // Company to GetCompaniesDto
            config.NewConfig<Company, GetCompaniesDto>()
                .Map(dest => dest.CompanyId, src => src.Id)
                .Map(dest => dest.CompanyName, src => src.Name)
                .Map(dest => dest.Branches, src => src.Branches
                    .Where(b => !b.IsDeleted && b.IsActive)
                    .OrderBy(b => b.Name));

            // Branch to GetBranchesDto
            config.NewConfig<Branch, GetBranchesDto>()
                .Map(dest => dest.BranchId, src => src.Id)
                .Map(dest => dest.BranchName, src => src.Name)
                .Map(dest => dest.Departments, src => src.Departments
                    .Where(d => !d.IsDeleted && d.IsActive)
                    .OrderBy(d => d.Name));

            // Department to GetDepartmentsDto
            config.NewConfig<Department, GetDepartmentsDto>()
                .Map(dest => dest.DepartmentId, src => src.Id)
                .Map(dest => dest.DepartmentName, src => src.Name)
                .Map(dest => dest.Teams, src => src.Teams
                    .Where(t => !t.IsDeleted && t.IsActive)
                    .OrderBy(t => t.Name));

            // Team to GetTeamsDto
            config.NewConfig<Team, GetTeamsDto>()
                .Map(dest => dest.TeamId, src => src.Id)
                .Map(dest => dest.TeamName, src => src.Name);
        }
    }
}

