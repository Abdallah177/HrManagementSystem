using HrManagementSystem.Common.Entities.Features;
using HrManagementSystem.Common.Entities.FeatureSope;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.ConfigurationsManagement.BreakManageMent.AddBreak.Commands;
using HrManagementSystem.Features.ConfigurationsManagement.ConfigurationScopeOrchestrator.ViewModels;
using HrManagementSystem.Features.ConfigurationsManagement.ConfigurationScopeOrchestrator;
using MediatR;
using HrManagementSystem.Common;

namespace HrManagementSystem.Features.ConfigurationsManagement.BreakManageMent.CreateBreakWithScopeOrchestrator
{
    public record CreateBreakWithScopeOrchestrator(
        string Name,
        TimeSpan Duration,
        bool IsPaid,
        MultiScopeViewModel ScopeViewModel
    ) : IRequest<RequestResult<bool>>;


    public class CreateBreakWithScopeOrchestratorHandler
    : RequestHandlerBase<CreateBreakWithScopeOrchestrator, RequestResult<bool>,Break>
    {
        public CreateBreakWithScopeOrchestratorHandler(RequestHandlerBaseParameters<Break> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(
            CreateBreakWithScopeOrchestrator request,
            CancellationToken cancellationToken)
        {
            // Step 1 → Add Break
            var addResult = await _mediator.Send(
                new AddBreakCommand(request.Name, request.Duration, request.IsPaid),
                cancellationToken);

            if (!addResult.IsSuccess)
                return RequestResult<bool>.Failure(addResult.Message, addResult.ErrorCode);

            var breakId = addResult.Data!.Id;


            // Step 2 → Assign to each scope level
            await AssignList(request.ScopeViewModel.CompanyIds, request, breakId, cancellationToken, "company");
            await AssignList(request.ScopeViewModel.BranchIds, request, breakId, cancellationToken, "branch");
            await AssignList(request.ScopeViewModel.DepartmentIds, request, breakId, cancellationToken, "dept");
            await AssignList(request.ScopeViewModel.TeamIds, request, breakId, cancellationToken, "team");


            return RequestResult<bool>.Success(true);
        }


        private async Task AssignList(
            List<string>? ids,
            CreateBreakWithScopeOrchestrator request,
            string breakId,
            CancellationToken cancellationToken,
            string type)
        {
            if (ids == null || ids.Count == 0)
                return;

            //foreach (var id in ids)
            //{
            //    var scopeVm = new ScopeViewModel
            //    {
            //        OrganizationId = request.ScopeViewModel.OrganizationId,
            //        CompanyId = type == "company" ? id : null,
            //        BranchId = type == "branch" ? id : null,
            //        DepartmentId = type == "dept" ? id : null,
            //        TeamId = type == "team" ? id : null,
            //    };

            //    //await _mediator.Send(
            //    //    new ConfigurationScopeOrchestrator<BreakScope, Break>(scopeVm, breakId),
            //    //    cancellationToken
            //    //);
            //}
        }
    }

}
