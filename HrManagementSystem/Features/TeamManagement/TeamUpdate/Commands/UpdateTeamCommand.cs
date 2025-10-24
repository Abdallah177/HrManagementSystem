using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.DepartmentManagement.Common.Queries;
<<<<<<< HEAD
=======
using HrManagementSystem.Features.TeamManagement.GetTeamById.Quesries;
>>>>>>> 884b38f3bdd3046d8c9a2da1850993b6540244f5
using HrManagementSystem.Features.TeamManagement.TeamUpdate.DTOs;
using Mapster;
using MediatR;
using MediatR.Wrappers;

namespace HrManagementSystem.Features.TeamManagement.TeamUpdate.Commands
{
    public record UpdateTeamCommand(string TeamID, string Name, string DepartmentID) : IRequest<RequestResult<UpdateTeamDto>>;

    public class UpdateTeamCommandHandler : RequestHandlerBase<UpdateTeamCommand, RequestResult<UpdateTeamDto>, Team>
    {
        public UpdateTeamCommandHandler(RequestHandlerBaseParameters<Team> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<UpdateTeamDto>> Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
        {
            var team = await _repository.GetByIDAsync(request.TeamID, cancellationToken);
            if (team == null)
                return RequestResult<UpdateTeamDto>.Failure("Team Not Found.", ErrorCode.TeamNotExist);

            var isDepartmentExist = await _mediator.Send(new CheckDepartmentIsExistQuery(request.DepartmentID));
            if (!isDepartmentExist.IsSuccess)
                return RequestResult<UpdateTeamDto>.Failure("Department Not Found.", ErrorCode.DepartmentNotExist);

            team.Name = request.Name;
            team.DepartmentId = request.DepartmentID;

            await _repository.UpdateIncludeAsync(team, request.TeamID, cancellationToken, nameof(Team.Name), nameof(Team.DepartmentId));
            
            var teamDto = team.Adapt<UpdateTeamDto>();
            return RequestResult<UpdateTeamDto>.Success(teamDto);
        }
    }
}
