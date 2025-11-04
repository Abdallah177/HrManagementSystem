using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.LocationManagement.CityManagement.DeleteCity.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.LocationManagement.CityManagement.DeleteCity
{
    public class DeleteCityEndpoint : BaseEndPoint<DeleteCityRequestViewModle, bool>
    {
        public DeleteCityEndpoint(EndpointBaseParameters<DeleteCityRequestViewModle> parameters) : base(parameters) { }

        [HttpDelete("")]

        public async Task<EndpointResponse<bool>> DeleteCity(DeleteCityRequestViewModle request)
        {
            var validition = ValidateRequest(request);

            if (!validition.IsSuccess)
                return validition;

            var UserId = GetCurrentUserId().ToString();

            var result = await _mediator.Send(new DeleteCityCommand(request.Id, UserId));
            if (!result.IsSuccess)
                return EndpointResponse<bool>.Failure(result.Message);

            return EndpointResponse<bool>.Success(true, "City deleted successfully");

        }
    }
}
