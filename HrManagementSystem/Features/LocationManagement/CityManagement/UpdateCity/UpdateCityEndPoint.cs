using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.LocationManagement.CityManagement.UpdateCity
{
    public class UpdateCityEndPoint : BaseEndPoint<UpdateCityRequestViewModel, bool>
    {
        public UpdateCityEndPoint(EndpointBaseParameters<UpdateCityRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpPut]
        public async Task<EndpointResponse<bool>> UpdateCity(UpdateCityRequestViewModel request, CancellationToken cancellationToken)
        {
            var validationResponse = ValidateRequest(request);
            if (!validationResponse.IsSuccess)
                return EndpointResponse<bool>.Failure(validationResponse.Message);

            var updateCityResult = await _mediator.Send(new Commands.UpdateCityCommand(request.cityId, request.Name, request.StateId, GetCurrentUserId().ToString()), cancellationToken);
            if (!updateCityResult.Data)
                return EndpointResponse<bool>.Failure(updateCityResult.Message , updateCityResult.ErrorCode);

            return EndpointResponse<bool>.Success(true, updateCityResult.Message);

        }
    }
}
