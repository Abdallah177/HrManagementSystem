using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.CompanyManagement.DeleteCompany.Commands;
using MediatR;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos;
using HrManagementSystem.Features.CompanyManagement.AddCompany.Dtos;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Company;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Branch;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Department;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Team;
using HrManagementSystem.Features.OnBoardingManagement.Commands.GenerateScope;
using HrManagementSystem.Features.OrganizationManagement.AddOrganization.Commands;

namespace HrManagementSystem.Features.OnBoardingManagement.Commands
{
    public record OnBoardingOrchestrator(OnBoardingDto OnBoardingDto, string currentUserId) : IRequest<RequestResult<bool>>;

    public class OnBoardingOrchestratorHandler : RequestHandlerBase<OnBoardingOrchestrator, RequestResult<bool>, Organization>
    {
        public OnBoardingOrchestratorHandler(RequestHandlerBaseParameters<Organization> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(OnBoardingOrchestrator request, CancellationToken cancellationToken)
        {
            var organizationResult = await _mediator.Send(new AddOrganizationCommand(request.OnBoardingDto.Organization.Name, request.currentUserId), cancellationToken);

            var companiesResult = await _mediator.Send(new OnBoardingCompainesCommand(request.OnBoardingDto.Organization.Companies,organizationResult.Data, request.currentUserId),cancellationToken);

            var branchesResult = await _mediator.Send(new OnBoardingBranchesCommand(companiesResult.Data, request.currentUserId),cancellationToken);

            var departmentsResult = await _mediator.Send(new OnBoardingDepartmentsCommand(branchesResult.Data, request.currentUserId), cancellationToken);

            var teamsResult = await _mediator.Send(new OnBoardingTeamsCommand(departmentsResult.Data,organizationResult.Data, request.currentUserId), cancellationToken);

            if (!teamsResult.IsSuccess)
                return RequestResult<bool>.Failure(teamsResult.Message, teamsResult.ErrorCode);

            //generate scops
            var generateScops = await _mediator.Send(new GenerateScopeCommand(teamsResult.Data, request.currentUserId));

            if (!generateScops.IsSuccess)
                return RequestResult<bool>.Failure(generateScops.Message, generateScops.ErrorCode);

            return RequestResult<bool>.Success(true, $"Organization onboarded successfully and created the scops correctly :{ generateScops.Data} scops!");

        }
    }
}
