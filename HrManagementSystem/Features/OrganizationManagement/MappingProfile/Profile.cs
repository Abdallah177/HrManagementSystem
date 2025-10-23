using HrManagementSystem.Common.Entities;
using HrManagementSystem.Features.BranchManagement.GetBranchById.Queries.Dtos;
using HrManagementSystem.Features.OrganizationManagement.GetAllOrganization.Queries.Dtos;
using Mapster;

namespace HrManagementSystem.Features.OrganizationManagement.MappingProfile
{
    public class Profile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Organization, GetAllOrganizationDto>()
              .Map(dest => dest.OrganizationId, src => src.Id)
              .Map(dest => dest.OrganizationName, src => src.Name);

            // Company to GetCompaniesDto mapping
            config.NewConfig<Company, GetCompaniesDto>()
                .Map(dest => dest.CompanyId, src => src.Id)
                .Map(dest => dest.CompanyName, src => src.Name);


            // Branch to GetBranchesDto mapping
            config.NewConfig<Branch, GetBranchesDto>()
                .Map(dest => dest.BranchId, src => src.Id)
                .Map(dest => dest.BranchName, src => src.Name);

            // Department to GetDepartmentsDto mapping
            config.NewConfig<Department, GetDepartmentsDto>()
                .Map(dest => dest.DepartmentId, src => src.Id)
                .Map(dest => dest.DepartmentName, src => src.Name);

            // Team to GetTeamsDto mapping
            config.NewConfig<Team, GetTeamsDto>()
                .Map(dest => dest.TeamId, src => src.Id)
                .Map(dest => dest.TeamName, src => src.Name);
        }
    }
}
