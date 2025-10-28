using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.Common.CheckExists;
using HrManagementSystem.Features.DepartmentManagement.GetDepartmentById.Query;
using HrManagementSystem.Features.DepartmentManagement.UpdateDepartmet.Dtos;
using MediatR;
using HrManagementSystem.Features.DepartmentManagement.Common.Queries;
using Mapster;

namespace HrManagementSystem.Features.DepartmentManagement.UpdateDepartmetn.Commands
{
    public record UpdateDepartmentCommand(string Id, string Name, string? Description, string BranchId)
    : IRequest<RequestResult<UpdateDepartmentDto>>;

    public class UpdateDepartmentCommandHandler
        : RequestHandlerBase<UpdateDepartmentCommand, RequestResult<UpdateDepartmentDto>, Department>
    {
        public UpdateDepartmentCommandHandler(RequestHandlerBaseParameters<Department> parameters)
            : base(parameters)
        {
        }

        public override async Task<RequestResult<UpdateDepartmentDto>> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            // CheckDepartmentExists
            var departmentResult = await _mediator.Send(new GetDepartmentByIdQuery(request.Id));

            if (!departmentResult.IsSuccess)
                return RequestResult<UpdateDepartmentDto>.Failure("Department Not Found", ErrorCode.DepartmentNotExist);

            // CheckBranchExists
            var isBranchExists = await _mediator.Send(new CheckExistsQuery<Branch>(request.BranchId));

            if (!isBranchExists)
                return RequestResult<UpdateDepartmentDto>.Failure("Branch Not Found", ErrorCode.BranchNotExist);

            // Check for duplicate department name in the same branch
            var isDuplicateDepartment = await _mediator.Send(new CheckDepartmentExistOnBranchQuery(request.Name, request.BranchId));

            if (!isDuplicateDepartment.IsSuccess)
                return RequestResult<UpdateDepartmentDto>.Failure("A department with the same name already exists in this branch.", ErrorCode.DuplicateRecord);

            var department = departmentResult.Data.Adapt<Department>();

            department.Name = request.Name;
            department.Description = request.Description;
            department.BranchId = request.BranchId;

            await _repository.UpdateIncludeAsync(
                department,
                "SYSTEM",
                cancellationToken,
                nameof(Department.Name),
                nameof(Department.Description),
                nameof(Department.BranchId)
            );

            var updateDepartmentDto = department.Adapt<UpdateDepartmentDto>();

            return RequestResult<UpdateDepartmentDto>.Success(updateDepartmentDto);
        }
    }





}
