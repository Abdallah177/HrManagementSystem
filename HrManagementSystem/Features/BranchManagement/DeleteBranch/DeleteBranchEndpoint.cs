using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.BranchManagement.DeleteBranch.Commands;
using HrManagementSystem.Features.BranchManagement.DeleteBranch.Orchestrators;
using HrManagementSystem.Features.TeamManagement.DeleteTeam;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.BranchManagement.DeleteBranch
{
    public class DeleteBranchEndpoint : BaseEndPoint<DeleteBranchRequestViewModel, bool>
    {
        public DeleteBranchEndpoint(EndpointBaseParameters<DeleteBranchRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpDelete]
        public async Task<EndpointResponse<bool>> DeleteBranch([FromQuery] DeleteBranchRequestViewModel request)
        {
            var validationResult = ValidateRequest(request);
            if (!validationResult.IsSuccess)
                return validationResult;

            var response =  await _mediator.Send(new DeleteBranchOrchestrator(request.Id, GetCurrentUserId().ToString()));
            if (!response.IsSuccess)
                return EndpointResponse<bool>.Failure(response.Message, response.ErrorCode);

            return EndpointResponse<bool>.Success(true);
        }
    }
}
