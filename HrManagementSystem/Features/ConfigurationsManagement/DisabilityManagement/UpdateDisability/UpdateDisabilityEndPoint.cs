using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.DisabilityManagement.UpdateDisability.Commands;
using HrManagementSystem.Features.LocationManagement.CityManagement.UpdateCity;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.DisabilityManagement.UpdateDisability
{
    public class UpdateDisabilityEndPoint : BaseEndPoint<UpdateDisabilityRequestViewModel, bool>
    {
        public UpdateDisabilityEndPoint(EndpointBaseParameters<UpdateDisabilityRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpPut]
        public async Task<EndpointResponse<bool>> UpdateDisability(UpdateDisabilityRequestViewModel request, CancellationToken cancellationToken)
        {
            var validationResult = ValidateRequest(request);
            if (!validationResult.IsSuccess)
                return validationResult;


            var updateDisabilityResult = await _mediator.Send(new UpdateDisabilityCommand(request.Id, request.Type, request.Description,request.RequiresSpecialSupport, GetCurrentUserId().ToString()), cancellationToken);
            if (!updateDisabilityResult.Data)
                return EndpointResponse<bool>.Failure(updateDisabilityResult.Message, updateDisabilityResult.ErrorCode);

            return EndpointResponse<bool>.Success(true, updateDisabilityResult.Message);
        }
    }
}
