using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.LocationManagement.CountryManagement.DeleteCountry.Commands;
using HrManagementSystem.Features.LocationManagement.CountryManagement.DeleteCountry;
using HrManagementSystem.Features.OrganizationManagement.GetAllOrganization;
using Microsoft.AspNetCore.Mvc;
using HrManagementSystem.Features.TeamManagement.Commands.DeleteTeam.Commands;

namespace HrManagementSystem.Features.TeamManagement.Commands.DeleteTeam
{
    public class DeleteTeamEndpoint : BaseEndPoint<object, bool>
    {
        public DeleteTeamEndpoint(EndpointBaseParameters<object> parameters) : base(parameters)
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
