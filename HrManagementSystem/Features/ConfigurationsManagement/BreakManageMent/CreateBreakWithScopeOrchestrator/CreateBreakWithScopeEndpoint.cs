using HrManagementSystem.Common.Views;
using HrManagementSystem.Common;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.ConfigurationsManagement.BreakManageMent.CreateBreakWithScopeOrchestrator
{
    public class CreateBreakWithScopeEndpoint
    : BaseEndPoint<CreateBreakWithScopeRequestViewModel, bool>
    {
        public CreateBreakWithScopeEndpoint(
            EndpointBaseParameters<CreateBreakWithScopeRequestViewModel> parameters
        ) : base(parameters)
        {
        }

        [HttpPost]
        public async Task<EndpointResponse<bool>> CreateBreakWithScope(
            CreateBreakWithScopeRequestViewModel request,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(
                new CreateBreakWithScopeOrchestrator(
                    request.Name,
                    request.Duration,
                    request.IsPaid,
                    request.ScopeViewModel
                ),
                cancellationToken
            );

            return EndpointResponse<bool>.Success(true);
        }
    }

}
