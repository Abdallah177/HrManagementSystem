using HrManagementSystem.Common.Entities;
using HrManagementSystem.Features.TeamManagement.GetAllTeams.DTOs;
using Mapster;

namespace HrManagementSystem.Features.TeamManagement.Common.MappingProfile
{
    public class GetAllTeamsProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {

            config.NewConfig<Team, GetAllTeamsDto>()
                .Map(dest => dest.TeamId, src => src.Id)
                .Map(dest => dest.TeamName, src => src.Name)
                .Map(dest => dest.DepartmentId, src => src.DepartmentId)
                .Map(dest => dest.DepartmentName, src => src.Department.Name);
        }
    }
}
