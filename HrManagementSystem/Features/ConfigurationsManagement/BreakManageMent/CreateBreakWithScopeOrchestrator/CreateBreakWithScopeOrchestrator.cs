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
        OrganizationViewModel ScopeViewModel
    ) : IRequest<RequestResult<bool>>;


    public class CreateBreakWithScopeOrchestratorHandler
    : RequestHandlerBase<CreateBreakWithScopeOrchestrator, RequestResult<bool>, Break>
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


            // Step 2 → Assign Break

            var response =await _mediator.Send(new ConfigurationScopeOrchestrator<BreakScope, Break>(request.ScopeViewModel, breakId));

            if (!response.IsSuccess)
                return RequestResult<bool>.Failure(response.Message, response.ErrorCode);

            return RequestResult<bool>.Success(true);
        }

    }
       
}
