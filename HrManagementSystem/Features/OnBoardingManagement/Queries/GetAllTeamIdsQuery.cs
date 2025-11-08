using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Department;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Team;
using MediatR;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.OnBoardingManagement.Queries
{
    public record GetAllTeamIdsQuery(List<string> departments) : IRequest<RequestResult<List<GetTeamIdsWithDepartmentIds>>>;

    public class GetAllTeamIdsQueryHandler : RequestHandlerBase<GetAllTeamIdsQuery, RequestResult<List<GetTeamIdsWithDepartmentIds>>, Team>
    {
        public GetAllTeamIdsQueryHandler(RequestHandlerBaseParameters<Team> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<List<GetTeamIdsWithDepartmentIds>>> Handle(GetAllTeamIdsQuery request, CancellationToken cancellationToken)
        {
            var teams = await _repository
           .Get(t => request.departments.Select(d => d).Contains(t.DepartmentId))
           .Select(t => new GetTeamIdsWithDepartmentIds 
           { 
               teamId = t.Id,
              departmentId = t.DepartmentId,
           })
           .ToListAsync(cancellationToken);

            return RequestResult<List<GetTeamIdsWithDepartmentIds>>.Success(teams);
        }
    }
}
