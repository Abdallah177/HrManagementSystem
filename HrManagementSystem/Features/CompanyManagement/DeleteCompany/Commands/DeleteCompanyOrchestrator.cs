using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.Common.CheckExists;
using HrManagementSystem.Features.TeamManagement.Commands.DeleteTeam.Commands;
using MediatR;

namespace HrManagementSystem.Features.CompanyManagement.DeleteCompany.Commands
{
    public record DeleteCompanyOrchestrator(string companyId) : IRequest<RequestResult<bool>>;

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
            var branchIds = await _branchRepository.GetAll()
                .Where(b => b.CompanyId == request.CompanyId && !b.IsDeleted)
                .Select(b => b.Id)
                .ToListAsync(cancellationToken);

            // Step 3: Orchestrate the deletion process
            await DeleteCompanyWithAllDependencies(request.CompanyId, branchIds, request.UserState.UserID);

            return RequestResult<DeleteCompanyResponse>.Success(
                new DeleteCompanyResponse("Company and all related data deleted successfully", DateTime.Now));
        }
    }


    private async Task DeleteCompanyWithAllDependencies(string companyId, List<string> branchIds, string currentUserId)
    {
        // Delete teams for all departments in all branches
        foreach (var branchId in branchIds)
        {
            // Get department IDs for this branch
            var departmentIds = await _mediator.Send(new GetDepartmentIdsByBranchQuery(branchId));

            // Delete teams for each department
            foreach (var departmentId in departmentIds)
            {
                await _mediator.Send(new DeleteTeamsCommand(departmentId, currentUserId));
            }

            // Delete departments for this branch
            await _mediator.Send(new DeleteDepartmentsCommand(branchId, currentUserId));
        }

        // Delete all branches for the company
        await _mediator.Send(new DeleteBranchesCommand(companyId, currentUserId));

        // Finally, delete the company itself
        await _companyRepository.DeleteAsync(companyId);
    }
}


