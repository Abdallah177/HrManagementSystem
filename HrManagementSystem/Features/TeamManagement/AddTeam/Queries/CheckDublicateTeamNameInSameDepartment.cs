using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.TeamManagement.AddTeam.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.TeamManagement.AddTeam.Queries
{
    public record CheckDublicateTeamNameInSameDepartment (string TeamName , string DepartmentId):IRequest<bool>;

    public class CheckDublicateTeamNameInSameDepartmentHandler : RequestHandlerBase<CheckDublicateTeamNameInSameDepartment, bool, Team>
    {
        public CheckDublicateTeamNameInSameDepartmentHandler(RequestHandlerBaseParameters<Team> parameters) : base(parameters)
        {
        }

        public override async Task<bool> Handle(CheckDublicateTeamNameInSameDepartment request, CancellationToken cancellationToken)
        {
            var result =await _repository.Get(T => T.Name == request.TeamName && T.DepartmentId == request.DepartmentId).AnyAsync(cancellationToken);

            return result;
        }
    }


}
