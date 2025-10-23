using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using MediatR;
using MediatR.Wrappers;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.TeamManagement.Common.Queries
{
    public record IsTeamExist(string Id) : IRequest<bool>;

    public class IsTeamExistHandler : RequestHandlerBase<IsTeamExist, bool, Team>
    {
        public IsTeamExistHandler(RequestHandlerBaseParameters<Team> parameters) : base(parameters)
        {
        }

        public override async Task<bool> Handle(IsTeamExist request, CancellationToken cancellationToken)
        {
            var IsExists =await _repository.GetAll().AnyAsync(T => T.Id == request.Id);

            if (IsExists) 
                return true;

            return false;
        }
    }

}
