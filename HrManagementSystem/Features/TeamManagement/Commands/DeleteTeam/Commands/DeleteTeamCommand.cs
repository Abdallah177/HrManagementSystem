using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.TeamManagement.Common.Queries;
using MediatR;

namespace HrManagementSystem.Features.TeamManagement.Commands.DeleteTeam.Commands
{
    public record DeleteTeamCommand(string TeamId , string currentUserId) :IRequest<RequestResult<bool>>;
    public class DeleteTeamCommandHandler : RequestHandlerBase<DeleteTeamCommand, RequestResult<bool>, Team>
    {
        public DeleteTeamCommandHandler(RequestHandlerBaseParameters<Team> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
        {
            var IsteamExist = await _mediator.Send(new IsTeamExist(request.TeamId));
            if (!IsteamExist)
                return RequestResult<bool>.Failure("Team not found", ErrorCode.TeamNotExist);
            //Check if team has active employees

            await _repository.DeleteAsync(request.TeamId , request.currentUserId,cancellationToken);
            return RequestResult<bool>.Success(true, "Team deleted successfully");


        }
    }

}
