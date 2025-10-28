using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.Common.CheckExists;
using HrManagementSystem.Features.Common.DeleteBranchesByCompany.Commands;
using HrManagementSystem.Features.Common.DeleteDepartmentsByBranch.Commands;
using HrManagementSystem.Features.Common.DeleteTeamsByDepartment.Commands;
using HrManagementSystem.Features.CompanyManagement.DeleteCompany.Queries;
using HrManagementSystem.Features.TeamManagement.Commands.DeleteTeam.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace HrManagementSystem.Features.CompanyManagement.DeleteCompany.Commands
{
    public record DeleteCompanyOrchestrator(string companyId , string currentUserId) : IRequest<RequestResult<bool>>;

    public class DeleteCompanyOrchestratorHandler : RequestHandlerBase<DeleteCompanyOrchestrator, RequestResult<bool>, Company>
    {
        public DeleteCompanyOrchestratorHandler(RequestHandlerBaseParameters<Company> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(DeleteCompanyOrchestrator request, CancellationToken cancellationToken)
        {
            var IsCompanyExist = await _mediator.Send(new CheckExistsQuery<Company>(request.companyId));
            if (!IsCompanyExist)
                return RequestResult<bool>.Failure("Company not found", ErrorCode.CompanyNotExist);

            // Step 2: Get all branches for this company
            var branchIds = await _mediator.Send(new GetBranchIdsByCompanyQuery(request.companyId));

            // Step 3: Orchestrate the deletion process
            // Delete teams for all departments in all branches
            foreach (var branchId in branchIds.Data)
            {
                // Get department IDs for this branch
                var departmentIds = await _mediator.Send(new GetDepartmentIdsByBranchQuery(branchId));

                // Delete teams for each department
                foreach (var departmentId in departmentIds.Data)
                {
                    await _mediator.Send(new DeleteTeamsByDepartmentCommand(departmentId, request.currentUserId));
                }

                // Delete departments for this branch
                await _mediator.Send(new DeleteDepartmentsByBranchCommand(branchId, request.currentUserId));
            }

            // Delete all branches for the company
            await _mediator.Send(new DeleteBranchesByCompanyCommand(request.companyId, request.currentUserId));

            // Finally, delete the company itself
            await _repository.DeleteAsync(request.companyId ,request.companyId,cancellationToken);

            return RequestResult<bool>.Success(true , "Company and all related data deleted successfully");
        }
    }
}




