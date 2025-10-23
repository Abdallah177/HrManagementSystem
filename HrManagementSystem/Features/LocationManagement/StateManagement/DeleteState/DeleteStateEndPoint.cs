using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.LocationManagement.StateManagement.DeleteState
{
    public class DeleteStateEndPoint : BaseEndPoint<DeleteStateRequestViewModel, bool>
    {
        public DeleteStateEndPoint(EndpointBaseParameters<DeleteStateRequestViewModel> parameters) : base(parameters)
        {
        }
        [HttpDelete]
        public EndpointResponse<bool> DeleteState([FromQuery] DeleteStateRequestViewModel request)
        {
            var validationResponse = ValidateRequest(request);
            if (!validationResponse.IsSuccess)
                return EndpointResponse<bool>.Failure(validationResponse.Message);
            var command = new Commands.DeleteStateCommand(request.StateId, GetCurrentUserId().ToString());
            var result = _mediator.Send(command).Result;
            if (!result.IsSuccess)
                return EndpointResponse<bool>.Failure(result.Message);
            return EndpointResponse<bool>.Success(result.Data, result.Message);
        }
    }
    
}
