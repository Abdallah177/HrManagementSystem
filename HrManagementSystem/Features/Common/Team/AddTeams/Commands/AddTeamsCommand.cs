using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Team;
using MediatR;
using Mapster;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Department;
using HrManagementSystem.Features.TeamManagement.GetTeamById.Dtos;
using HrManagementSystem.Features.Common.Team.AddTeams.Dtos;

namespace HrManagementSystem.Features.Common.Team.AddTeams.Commands
{
    public record AddTeamsCommand(List<AddTeamsRequestDto> teamsRequestDto, string OrganizationId, string currentUserId) : IRequest<RequestResult<List<TeamsResponseDto>>>;

    public class AddTeamsCommandHandler : RequestHandlerBase<AddTeamsCommand, RequestResult<List<TeamsResponseDto>>, HrManagementSystem.Common.Entities.Team>
    {
        public AddTeamsCommandHandler(RequestHandlerBaseParameters<HrManagementSystem.Common.Entities.Team> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<List<TeamsResponseDto>>> Handle(AddTeamsCommand request, CancellationToken cancellationToken)
        {
            var teamsResponses = new List<TeamsResponseDto>();

            var teamsWithScopes = request.teamsRequestDto
             .SelectMany(dept =>
               dept.Teams != null && dept.Teams.Count != 0
                ? dept.Teams
                   .Select(team => new
                   {
                       Team = team with { DepartmentId = dept.DepartmentId },
                       dept.BranchId,
                       dept.CompanyId
                   })
                : new[]
                {
                    new
                    {
                        Team = new TeamsDto($"{dept.DepartmentName} Team", dept.DepartmentId),
                        dept.BranchId,
                        dept.CompanyId
                    }

                }).ToList();


            var teams = teamsWithScopes.Select(x => x.Team).Adapt<List<HrManagementSystem.Common.Entities.Team>>();
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

