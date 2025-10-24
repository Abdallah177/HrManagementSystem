using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using Microsoft.AspNetCore.Mvc;
using HrManagementSystem.Features.TeamManagement.Commands.DeleteTeam.Commands;
using HrManagementSystem.Features.LocationManagement.CountryManagement.Commands.DeleteCountry;

namespace HrManagementSystem.Features.TeamManagement.Commands.DeleteTeam
{
    public class DeleteTeamEndpoint : BaseEndPoint<DeleteTeamRequestViewModel, bool>
    {
        public DeleteTeamEndpoint(EndpointBaseParameters<DeleteTeamRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpDelete]
        public async Task<EndpointResponse<bool>> DeleteTeam([FromQuery] DeleteTeamRequestViewModel request)
        {
            var validationResponse = ValidateRequest(request);
            if (!validationResponse.IsSuccess)
                return EndpointResponse<bool>.Failure(validationResponse.Message);

            var result = await _mediator.Send(new DeleteTeamCommand(request.TeamId, GetCurrentUserId().ToString()));

            if (!result.IsSuccess)
                return EndpointResponse<bool>.Failure(result.Message);

            return EndpointResponse<bool>.Success(result.Data, result.Message);
        }
    }
}
