using HrManagementSystem.Common.Entities;
using HrManagementSystem.Features.DepartmentManagement.GetAllDepartment.Queries.Dtos;
using Mapster;

namespace HrManagementSystem.Features.DepartmentManagement.MappingProfile
{
    public class Profile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Department, GetAllDepartmentDto>()
              .Map(dest => dest.DepartmentId, src => src.Id)
              .Map(dest => dest.DepartmentName, src => src.Name)
              .Map(dest => dest.BranchId, src => src.Id)
              .Map(dest => dest.BranchName, src => src.Branch.Name)
              .Map(dest => dest.Teams, src => src.Teams
              .Where(t => !t.IsDeleted && t.IsActive)
              .OrderBy(t => t.Name));

            config.NewConfig<Team, DepartmentTeamDto>()
                .Map(dest => dest.TeamId, src => src.Id)
                .Map(dest => dest.TeamName, src => src.Name);
        }
    }
}
