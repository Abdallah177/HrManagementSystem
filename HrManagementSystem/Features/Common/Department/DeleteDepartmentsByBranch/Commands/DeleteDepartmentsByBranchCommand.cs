using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.Common.CheckExists;
using MediatR;

namespace HrManagementSystem.Features.Common.Department.DeleteDepartmentsByBranch.Commands
{
    public record DeleteDepartmentsByBranchCommand(string branchId, string currentUserId) : IRequest<RequestResult<bool>>;

    public class DeleteDepartmentsByBranchCommandHandler : RequestHandlerBase<DeleteDepartmentsByBranchCommand, RequestResult<bool>, HrManagementSystem.Common.Entities.Department>
    {
        public DeleteDepartmentsByBranchCommandHandler(RequestHandlerBaseParameters<HrManagementSystem.Common.Entities.Department> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(DeleteDepartmentsByBranchCommand request, CancellationToken cancellationToken)
        {
            //var IsBranchExist = await _mediator.Send(new CheckExistsQuery<Branch>(request.branchId));
            //if (!IsBranchExist)
            //    return RequestResult<bool>.Failure("Branch not found", ErrorCode.BranchNotFound);
            await _repository.DeleteAsync(request.branchId, request.currentUserId, cancellationToken);
            return RequestResult<bool>.Success(true, "Departments deleted successfully");
        }
    }
}
