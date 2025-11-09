using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.ConfigurationsManagement.VacationMangement.DeleteVacation.Commands;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.ConfigurationsManagement.VacationMangement.DeleteVacation
{
    public class DeleteVacationEndPoint : BaseEndPoint<DeleteVacationRequestViewModel, bool>
    {
        public DeleteVacationEndPoint(EndpointBaseParameters<DeleteVacationRequestViewModel> parameters) : base(parameters)
        {
        }
        [HttpDelete]
        public async Task<EndpointResponse<bool>> DeleteVacation([FromQuery] DeleteVacationRequestViewModel request)
        {
            var response = await _mediator.Send(new DeleteVacationCommand(request.Id, "System"));
            if (!response.IsSuccess)
                return EndpointResponse<bool>.Failure(response.Message, response.ErrorCode);
            return EndpointResponse<bool>.Success(true);
        }
    }
    
}
