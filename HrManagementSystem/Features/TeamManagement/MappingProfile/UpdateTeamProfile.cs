using HrManagementSystem.Common.Entities;
using HrManagementSystem.Features.TeamManagement.TeamUpdate;
using HrManagementSystem.Features.TeamManagement.TeamUpdate.DTOs;
using Mapster;

namespace HrManagementSystem.Features.TeamManagement.MappingProfile
{
    public class UpdateTeamProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Team, UpdateTeamDto>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.DepartmentId, src => src.DepartmentId);
        }
    }
    
}
