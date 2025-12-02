using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Features;
using HrManagementSystem.Common.Entities.FeatureSope;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.ConfigurationsManagement.ConfigurationScopeOrchestrator;
using HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.AddRequest.Command;
using HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.AddRequest.RequestOrchestrator;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.AddRequest
{
    public class RequestAddRequestEndPoint : BaseEndPoint<AddRequestViewModelWithScop, bool>
    {
        public RequestAddRequestEndPoint(EndpointBaseParameters<AddRequestViewModelWithScop> parameters) : base(parameters)
        {
        }
        [HttpPost]
        public async Task<EndpointResponse<bool>> AddRequest(AddRequestViewModelWithScop assignConfig, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new AddRequestWithScopOrchestrator(
                assignConfig.Title,
                assignConfig.Status,
                assignConfig.Description,
                  assignConfig.ScopeViewModel),
                cancellationToken);

            return EndpointResponse<bool>.Success(true);
        }

    }
}
