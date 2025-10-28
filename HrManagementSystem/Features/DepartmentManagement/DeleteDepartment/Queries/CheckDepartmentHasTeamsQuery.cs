using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Views;
using MediatR;

namespace HrManagementSystem.Features.DepartmentManagement.DeleteDepartment.Queries
{
    public record CheckDepartmentHasTeamsQuery (string DepartmentId) : IRequest<RequestResult<bool>>;

    public class CheckDepartmentHasTeamsQueryHandler : RequestHandlerBase<CheckDepartmentHasTeamsQuery, RequestResult<bool>, Team>
    {
        public CheckDepartmentHasTeamsQueryHandler(RequestHandlerBaseParameters<Team> parameters)
            : base(parameters)
        {
        }
        public async override Task<RequestResult<bool>> Handle(CheckDepartmentHasTeamsQuery request, CancellationToken cancellationToken)
        {
            var hasTeams = await _repository.IsExistsAsync(t => t.DepartmentId == request.DepartmentId);
            return RequestResult<bool>.Success(hasTeams);
        }
    }



}
