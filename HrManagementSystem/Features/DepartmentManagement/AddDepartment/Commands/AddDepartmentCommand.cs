using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.BranchManagement.Common.CheckBranchExists;
using HrManagementSystem.Features.DepartmentManagement.Common.Queries;
using Mapster;
using MediatR;

namespace HrManagementSystem.Features.DepartmentManagement.AddDepartment.Commands
{
    public record AddDepartmentCommand(string Name, string Description, string BranchId, string currentUserId) : IRequest<RequestResult<bool>>;
    public class AddDepartmentCommandHandler : RequestHandlerBase<AddDepartmentCommand, RequestResult<bool>, Department>
    {
        public AddDepartmentCommandHandler(RequestHandlerBaseParameters<Department> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(AddDepartmentCommand request, CancellationToken cancellationToken)
        {
            var branchExistsResult = await _mediator.Send(new CheckBranchExistsQuery(request.BranchId));
            if (!branchExistsResult.Data)
                return RequestResult<bool>.Failure("Branch not found", ErrorCode.BranchNotExist);

            var departmentExistsResult = await _mediator.Send(new CheckDepartmentExistOnBranchQuery(request.Name, request.BranchId));
            if (departmentExistsResult.Data)
                return RequestResult<bool>.Failure("Department with this name already exists in this branch", ErrorCode.DepartmentIsExist);

            var department = request.Adapt<Department>();

            await _repository.AddAsync(department, request.currentUserId, cancellationToken);
            return RequestResult<bool>.Success(true, "Department created successfully");
        }
    }
}
