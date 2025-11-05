using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.ConfigurationsManagement.ProbationMangement.DeleteProbation.Commands;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.ConfigurationsManagement.ProbationMangement.DeleteProbation
{
    public class DeleteProbationEndPoint : BaseEndPoint<DeleteProbationRequestViewModel, bool>
    {
        public DeleteProbationEndPoint(EndpointBaseParameters<DeleteProbationRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpDelete]
        public async Task<EndpointResponse<bool>> DeleteProbation([FromQuery] DeleteProbationRequestViewModel request)
        {
            var response = await _mediator.Send(new DeleteProbationCommand(request.Id, "System"));
            if (!response.IsSuccess)
                return EndpointResponse<bool>.Failure(response.Message, response.ErrorCode);
            return EndpointResponse<bool>.Success(true);
        }

    }
}
