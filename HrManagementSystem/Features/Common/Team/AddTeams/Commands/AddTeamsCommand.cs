using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using MediatR;
using Mapster;
using HrManagementSystem.Features.Common.Team.AddTeams.Dtos;

namespace HrManagementSystem.Features.Common.Team.AddTeams.Commands
{
    public record AddTeamsCommand(List<AddTeamsHierarchyRequestDto> teamsReuestDto, string OrganizationId, string currentUserId) : IRequest<RequestResult<List<TeamsResponseDto>>>;

    public class AddTeamsCommandHandler : RequestHandlerBase<AddTeamsCommand, RequestResult<List<TeamsResponseDto>>, HrManagementSystem.Common.Entities.Team>
    {
        public AddTeamsCommandHandler(RequestHandlerBaseParameters<HrManagementSystem.Common.Entities.Team> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<List<TeamsResponseDto>>> Handle(AddTeamsCommand request, CancellationToken cancellationToken)
        {
            var teamsResponses = new List<TeamsResponseDto>();

            var teamsWithScopes = request.teamsReuestDto
             .SelectMany(dept =>
               (dept.Teams != null && dept.Teams.Count != 0)
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

