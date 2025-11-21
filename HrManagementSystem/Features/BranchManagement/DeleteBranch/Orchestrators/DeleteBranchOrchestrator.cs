using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.BranchManagement.DeleteBranch.Commands;
using HrManagementSystem.Features.Common.CheckExists;
using HrManagementSystem.Features.Common.Department.DeleteDepartmentsByBranch.Commands;
using HrManagementSystem.Features.Common.Team.DeleteTeamsByDepartment.Commands;
using HrManagementSystem.Features.CompanyManagement.DeleteCompany.Commands;
using HrManagementSystem.Features.CompanyManagement.DeleteCompany.Queries;
using MediatR;

namespace HrManagementSystem.Features.BranchManagement.DeleteBranch.Orchestrators
{
    public record DeleteBranchOrchestrator(string branchId , string currentUserId): IRequest<RequestResult<bool>>;

    public class DeleteBranchOrchestratorHandler : RequestHandlerBase<DeleteBranchOrchestrator, RequestResult<bool>, Company>
    {
        public DeleteBranchOrchestratorHandler(RequestHandlerBaseParameters<Company> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(DeleteBranchOrchestrator request, CancellationToken cancellationToken)
        {
            var IsBranchExists = await _mediator.Send(new CheckExistsQuery<Branch>(request.branchId));

            if (!IsBranchExists)
                return RequestResult<bool>.Failure("Branch Not Found", ErrorCode.BranchNotExist);

            var departmentIds = await _mediator.Send(new GetDepartmentIdsByBranchQuery(request.branchId));

            // Delete teams for each department
            foreach (var departmentId in departmentIds.Data)
            {
                await _mediator.Send(new DeleteTeamsByDepartmentCommand(departmentId, request.currentUserId));
            }

            // Delete departments for this branch
            await _mediator.Send(new DeleteDepartmentsByBranchCommand(request.branchId, request.currentUserId));

            var result = await _mediator.Send(new DeleteBranchCommand(request.branchId , request.currentUserId));

            return RequestResult<bool>.Success(result.IsSuccess,result.Message);
        }
    }
   
}
