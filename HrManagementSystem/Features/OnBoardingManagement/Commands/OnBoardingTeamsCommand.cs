using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Team;
using MediatR;
using Mapster;

namespace HrManagementSystem.Features.OnBoardingManagement.Commands
{
    public record OnBoardingTeamsCommand(List<TeamsDto> Teams, string CurrentUserId) : IRequest<RequestResult<List<TeamsResponseDto>>>;

    public class OnBoardingTeamsCommandHandler : RequestHandlerBase<OnBoardingTeamsCommand, RequestResult<List<TeamsResponseDto>>, Team>
    {
        public OnBoardingTeamsCommandHandler(RequestHandlerBaseParameters<Team> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<List<TeamsResponseDto>>> Handle(OnBoardingTeamsCommand request, CancellationToken cancellationToken)
        {
            var teamsResponses = new List<TeamsResponseDto>();

            foreach (var teamDto in request.Teams)
            {
                var team = teamDto.Adapt<Team>();
                await _repository.AddAsync(team, request.CurrentUserId, cancellationToken);

                teamsResponses.Add(new TeamsResponseDto
                {
                    TeamId = team.Id
                });
            }

            return RequestResult<List<TeamsResponseDto>>.Success(teamsResponses, "Teams created successfully");
        }
    }
}

