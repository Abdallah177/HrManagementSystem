using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.LocationManagement.CountryManagement.Commands.DeleteCountry.Commands;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.LocationManagement.CountryManagement.Commands.DeleteCountry
{
    public class DeleteCountryEndPoint : BaseEndPoint<DeleteCountryRequestViewModel, bool>
    {
        public DeleteCountryEndPoint(EndpointBaseParameters<DeleteCountryRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpDelete]
        public async Task<EndpointResponse<bool>> DeleteCountry([FromQuery] DeleteCountryRequestViewModel request)
        {
            var validationResponse = ValidateRequest(request);
            if (!validationResponse.IsSuccess)
                return EndpointResponse<bool>.Failure(validationResponse.Message);

            var result = await _mediator.Send(new DeleteCountryCommand(request.CountryId, GetCurrentUserId().ToString()));

            if (!result.IsSuccess)
                return EndpointResponse<bool>.Failure(result.Message);

            return EndpointResponse<bool>.Success(result.Data, result.Message);
        }

    }
}
