using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.Common.CheckExists;
using HrManagementSystem.Features.DepartmentManagement.DeleteDepartment.Queries;
using MediatR;

namespace HrManagementSystem.Features.DepartmentManagement.DeleteDepartment.Commands
{
    public record DeleteDepartmentCommand (string DepartmentId, string currentUserId) : IRequest<RequestResult<bool>>;

    public class DeleteDepartmentCommandHandler : RequestHandlerBase<DeleteDepartmentCommand, RequestResult<bool>, Department>
    {
        public DeleteDepartmentCommandHandler(RequestHandlerBaseParameters<Department> parameters)
            : base(parameters)
        {
        }
        public async override Task<RequestResult<bool>> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            // Check if Department exists
            var departmentExists = await _mediator.Send(new CheckExistsQuery<Department>(request.DepartmentId), cancellationToken);
            if (!departmentExists)
                return RequestResult<bool>.Failure("Department not found", ErrorCode.DepartmentNotExist);

            // Check if Department has related Teams
            var hasTeams = await _mediator.Send(new CheckDepartmentHasTeamsQuery(request.DepartmentId), cancellationToken);
            if (hasTeams.Data)
                return RequestResult<bool>.Failure("Department has related teams", ErrorCode.DepartmentHasRelatedTeams);

            await _repository.DeleteAsync(request.DepartmentId, request.currentUserId, cancellationToken);
            return RequestResult<bool>.Success(true, "Department deleted successfully");

        }
    }

}
