using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.TeamManagement.GetTeamById.Dtos;
using Mapster;
using MediatR;

namespace HrManagementSystem.Features.TeamManagement.GetTeamById.Quesries
{
    public record GetTeamByIdQuery(string Id) : IRequest<RequestResult<TeamDto>>;

    public class GetTeamByIdQueryHandler : RequestHandlerBase<GetTeamByIdQuery, RequestResult<TeamDto>, Team>
    {
        public GetTeamByIdQueryHandler(RequestHandlerBaseParameters<Team> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<TeamDto>> Handle(GetTeamByIdQuery request, CancellationToken cancellationToken)
        {
            var team = await _repository.GetByIDAsync(request.Id, cancellationToken);

            if (team == null)
                return RequestResult<TeamDto>.Failure("TeamNotExist", ErrorCode.TeamNotExist);

            var teamDto = team.Adapt<TeamDto>();

            return RequestResult<TeamDto>.Success(teamDto);

        }
    }



}
