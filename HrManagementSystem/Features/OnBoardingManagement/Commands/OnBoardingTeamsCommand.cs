using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Team;
using MediatR;
using Mapster;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Department;
using HrManagementSystem.Features.TeamManagement.GetTeamById.Dtos;

namespace HrManagementSystem.Features.OnBoardingManagement.Commands
{
    public record OnBoardingTeamsCommand(List<DepartmentsResponseDto> Departments, string OrganizationId, string currentUserId) : IRequest<RequestResult<List<TeamsResponseDto>>>;

    public class OnBoardingTeamsCommandHandler : RequestHandlerBase<OnBoardingTeamsCommand, RequestResult<List<TeamsResponseDto>>, Team>
    {
        public OnBoardingTeamsCommandHandler(RequestHandlerBaseParameters<Team> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<List<TeamsResponseDto>>> Handle(OnBoardingTeamsCommand request, CancellationToken cancellationToken)
        {
            var teamsResponses = new List<TeamsResponseDto>();

            var teamsWithScopes = request.Departments
                .SelectMany(dept =>
                    dept.Teams?.Where(t => t != null).Select(team => new 
                    {
                        Team = team with { DepartmentId = dept.DepartmentId},
                        dept.BranchId,
                        dept.CompanyId
                    })
                    ?? new[] 
                    {
                        new 
                        {
                            Team = new TeamsDto($"{dept.DepartmentName} Team", dept.DepartmentId),
                             dept.BranchId,
                             dept.CompanyId
                        }
                    }).ToList();

            var teamDtos = teamsWithScopes.Select(x => x.Team).ToList();

            var teams = teamDtos.Adapt<List<Team>>();
            await _repository.AddRangeAsync(teams, request.currentUserId, cancellationToken);

             teamsResponses = teams.Select((team, index) => new TeamsResponseDto
            {
                TeamId = team.Id,
                DepartmentId = team.DepartmentId,
                BranchId = teamsWithScopes[index].BranchId, 
                CompanyId = teamsWithScopes[index].CompanyId,  
                OrganizationId = request.OrganizationId

            }).ToList();


            return RequestResult<List<TeamsResponseDto>>.Success(teamsResponses, "Teams created successfully");
        }
    }
}

