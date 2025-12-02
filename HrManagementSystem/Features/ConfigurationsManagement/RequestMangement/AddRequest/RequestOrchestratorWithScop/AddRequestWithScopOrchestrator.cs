using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Features;
using HrManagementSystem.Common.Entities.FeatureSope;
using HrManagementSystem.Common.Enums.FeatureEnums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.ConfigurationsManagement.BreakManageMent.AddBreak.Commands;
using HrManagementSystem.Features.ConfigurationsManagement.BreakManageMent.CreateBreakWithScopeOrchestrator;
using HrManagementSystem.Features.ConfigurationsManagement.ConfigurationScopeOrchestrator;
using HrManagementSystem.Features.ConfigurationsManagement.ConfigurationScopeOrchestrator.ViewModels;
using HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.AddRequest.Command;
using MediatR;

namespace HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.AddRequest.RequestOrchestrator
{
    public record AddRequestWithScopOrchestrator(string Title, RequestStatus Status, string Description, OrganizationViewModel ScopeViewModel):
         IRequest<RequestResult<bool>>;

    public class AddRequestWithScopOrchestratorHandler : RequestHandlerBase<AddRequestWithScopOrchestrator, RequestResult<bool>, Request>
    {
        public AddRequestWithScopOrchestratorHandler(RequestHandlerBaseParameters<Request> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(
           AddRequestWithScopOrchestrator request,
           CancellationToken cancellationToken)
        {
            // Step 1 → Add Request =>property
            var addResult = await _mediator.Send(
                new AddRequestCommand(request.Title, request.Status, request.Description),
                cancellationToken);

            if (!addResult.IsSuccess)
                return RequestResult<bool>.Failure(addResult.Message, addResult.ErrorCode);

            var requestId = addResult.Data!.Id;


            // Step 2 → Assign Request => Ids

            var response = await _mediator.Send(new ConfigurationScopeOrchestrator<RequestScope, Request>(request.ScopeViewModel, requestId));

            if (!response.IsSuccess)
                return RequestResult<bool>.Failure(response.Message, response.ErrorCode);

            return RequestResult<bool>.Success(true);
        }

    }

}



