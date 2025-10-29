using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.Common.CheckExists;
using MediatR;

namespace HrManagementSystem.Features.Common.Team.DeleteTeamsByDepartment.Commands
{
    public record DeleteTeamsByDepartmentCommand(string departmentId, string currentUserId) : IRequest<RequestResult<bool>>;

    public class DeleteTeamsByDepartmentCommandHandler : RequestHandlerBase<DeleteTeamsByDepartmentCommand, RequestResult<bool>, HrManagementSystem.Common.Entities.Team>
    {
        public DeleteTeamsByDepartmentCommandHandler(RequestHandlerBaseParameters<HrManagementSystem.Common.Entities.Team> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(DeleteTeamsByDepartmentCommand request, CancellationToken cancellationToken)
        {
            //var IsDepartmentExist = await _mediator.Send(new CheckExistsQuery<Department>(request.departmentId));
            //if (!IsDepartmentExist)
            //    return RequestResult<bool>.Failure("Department not found", ErrorCode.NoDepartmentsFound);

            await _repository.DeleteAsync(request.departmentId, request.currentUserId, cancellationToken);
            return RequestResult<bool>.Success(true, "Teams deleted successfully");
        }
    }
}
