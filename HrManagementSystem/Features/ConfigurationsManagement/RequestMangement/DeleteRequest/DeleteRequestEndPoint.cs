using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.DeleteRequest.Commands;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.DeleteRequest
{
    public class DeleteRequestEndPoint : BaseEndPoint<DeleteRequestRequestViewModel, bool>
    {
        public DeleteRequestEndPoint(EndpointBaseParameters<DeleteRequestRequestViewModel> parameters) : base(parameters)
        {
        }
        [HttpDelete]
        public async Task<EndpointResponse<bool>> DeleteRequest([FromQuery] DeleteRequestRequestViewModel request)
        {
            var response = await _mediator.Send(new DeleteRequestCommand(request.Id, "System"));

            if (!response.IsSuccess)
                return EndpointResponse<bool>.Failure(response.Message, response.ErrorCode);
            return EndpointResponse<bool>.Success(true);
        }
    }
   
}
