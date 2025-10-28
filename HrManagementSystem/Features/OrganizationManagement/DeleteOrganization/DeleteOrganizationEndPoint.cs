using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.OrganizationManagement.DeleteOrganization.Commands;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.OrganizationManagement.DeleteOrganization
{
    public class DeleteOrganizationEndPoint : BaseEndPoint<DeleteOrganizationRequestViewModel, bool>
    {
        public DeleteOrganizationEndPoint(EndpointBaseParameters<DeleteOrganizationRequestViewModel> parameters) : base(parameters)
        {
        }
        [HttpDelete]
        public async Task<EndpointResponse<bool>> DeleteOrganization([FromQuery] DeleteOrganizationRequestViewModel request)
        {
            var validationResponse = ValidateRequest(request);
            if (!validationResponse.IsSuccess)
                return EndpointResponse<bool>.Failure(validationResponse.Message);

            var result = await _mediator.Send(new DeleteOrganizationCommand(request.OrganizationId, GetCurrentUserId().ToString()));
            if (!result.IsSuccess)
                return EndpointResponse<bool>.Failure(result.Message);

            return EndpointResponse<bool>.Success(result.Data, result.Message);
        }
    }
}
