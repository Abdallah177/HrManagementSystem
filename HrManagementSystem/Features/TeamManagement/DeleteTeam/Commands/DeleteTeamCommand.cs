using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Views;
using MediatR;

namespace HrManagementSystem.Features.TeamManagement.Commands.DeleteTeam.Commands
{
    public record DeleteTeamCommand(string TeamId):IRequest<RequestResult<bool>>;
    public class DeleteTeamCommandHandler : RequestHandlerBase<DeleteTeamCommand, RequestResult<bool>, Team>
    {
        public DeleteTeamCommandHandler(RequestHandlerBaseParameters<Team> parameters) : base(parameters)
        {
        }

        public override Task<RequestResult<bool>> Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

}
