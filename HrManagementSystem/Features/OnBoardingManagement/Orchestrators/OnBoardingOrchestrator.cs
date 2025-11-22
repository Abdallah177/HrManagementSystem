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
using HrManagementSystem.Features.OrganizationManagement.AddOrganization.Commands;
using HrManagementSystem.Features.OnBoardingManagement.GenerateScope.Commands;
using Mapster;
using HrManagementSystem.Features.OnBoardingManagement.GenerateScope.Dtos;
using HrManagementSystem.Common.Enums;

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

            if (!organizationResult.IsSuccess)
              return RequestResult<bool>.Failure( organizationResult.Message , organizationResult.ErrorCode);


            var companiesRequest = request.OnBoardingDto.Organization.Companies.Adapt<List<AddCompaniesHierarchyRequestDto>>();
            var companiesResult = await _mediator.Send(new OnBoardingCompainesCommand(companiesRequest, organizationResult.Data, request.currentUserId), cancellationToken);

            var branchesRequest = companiesResult.Data.Adapt<List<AddBranchesHierarchyRequestDto>>();
            var branchesResult = await _mediator.Send(new OnBoardingBranchesCommand(branchesRequest, request.currentUserId),cancellationToken);

            var departmentRequest = branchesResult.Data.Adapt<List<AddDepartmentsHierarchyRequestDto>>();
            var departmentsResult = await _mediator.Send(new OnBoardingDepartmentsCommand(departmentRequest, request.currentUserId), cancellationToken);

            var teamsRequest = departmentsResult.Data.Adapt<List<AddTeamsHierarchyRequestDto>>();

            var teamsResult = await _mediator.Send(new OnBoardingTeamsCommand(teamsRequest,organizationResult.Data, request.currentUserId), cancellationToken);

            if (!teamsResult.IsSuccess)
                return RequestResult<bool>.Failure("The hierarchy added successfully", ErrorCode.FailToAddedHierarchy);

            //generate scops
            var fullScopesResult = teamsResult.Data.Adapt<List<GenerateScopesDto>>();
            var generateScops = await _mediator.Send(new GenerateScopeCommand(fullScopesResult, request.currentUserId));

            if (!generateScops.IsSuccess)
                return RequestResult<bool>.Failure("Failed to generate the full scopes to the hierarchy", ErrorCode.FailToAddFullScopes);

            return RequestResult<bool>.Success(true, $"Organization onboarded successfully and created the scops correctly :{ generateScops.Data} scops!");

        }
    }
}
