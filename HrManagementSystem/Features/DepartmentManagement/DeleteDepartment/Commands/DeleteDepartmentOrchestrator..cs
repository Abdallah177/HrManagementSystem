using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.Common.CheckExists;
using HrManagementSystem.Features.Common.Team.DeleteTeamsByDepartment.Commands;
using MediatR;

namespace HrManagementSystem.Features.DepartmentManagement.DeleteDepartment.Commands
{
    public record DeleteDepartmentOrchestrator(string departmentId , string currentUserId) : IRequest<RequestResult<bool>>;
    public class DeleteDepartmentOrchestratorHandler : RequestHandlerBase<DeleteDepartmentOrchestrator, RequestResult<bool>, Department>
    {
        public DeleteDepartmentOrchestratorHandler(RequestHandlerBaseParameters<Department> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(DeleteDepartmentOrchestrator request, CancellationToken cancellationToken)
        {
            var departmentExists = await _mediator.Send(new CheckExistsQuery<Department>(request.departmentId), cancellationToken);
            if (!departmentExists)
                return RequestResult<bool>.Failure("Department not found", ErrorCode.DepartmentNotExist);

            await _mediator.Send(new DeleteTeamsByDepartmentCommand(request.departmentId, request.currentUserId));

            await _mediator.Send(new DeleteDepartmentCommand(request.departmentId, request.currentUserId));

            return RequestResult<bool>.Success(true, "Department and all related data deleted successfully");
        }
    }
}
