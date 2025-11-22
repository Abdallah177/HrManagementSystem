using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Features;
using HrManagementSystem.Common.Entities.FeatureSope;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.ConfigurationsManagement.Common.DeleteConfigrationScope.Orchestrators;
using HrManagementSystem.Features.OnBoardingManagement.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace HrManagementSystem.Features.DisabilityManagement.DeleteDisability
{
    public class DeleteDisabilityEndPoint : BaseEndPoint<DeleteDisabilityRequestViewModel, bool>
    {
        public DeleteDisabilityEndPoint(EndpointBaseParameters<DeleteDisabilityRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpDelete]
        public async Task<EndpointResponse<bool>> DeleteDisability([FromQuery] DeleteDisabilityRequestViewModel request, CancellationToken cancellationToken)
        {
            var validationResult = ValidateRequest(request);
            if (!validationResult.IsSuccess)
                return validationResult;

            var result = await _mediator.Send(new DeleteConfigurationOrchestrator<Disability, DisabilityScope>
                (request.DisabilityId, GetCurrentUserId().ToString()), cancellationToken);

            return EndpointResponse<bool>.Success(result.Data, result.Message);
        }
    }
}
