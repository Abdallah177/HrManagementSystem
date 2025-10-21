using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.LocationManagement.CountryManagement.UpdateCountry.Commands;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.LocationManagement.CountryManagement.UpdateCountry
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateCountryController : BaseEndPoint<UpdateCountryRequestViewModle,bool>
    {
        public UpdateCountryController(EndpointBaseParameters<UpdateCountryRequestViewModle> parameters):base(parameters) { }


        [HttpPut]

        public async Task  <EndpointResponse<UpdateCountryResponseViewModel>> UpdateCountry (UpdateCountryRequestViewModle request)
        {

            var validation = ValidateRequest(request);
            if (!validation.IsSuccess)
                return EndpointResponse<UpdateCountryResponseViewModel>.Failure(validation.Message);

            var userId = GetCurrentUserId();

            var command = request.Adapt<UdateCountryCommand>();
            command.UpdatedByUser = userId.ToString();

            var result = await _mediator.Send(command);

           
            if (!result.IsSuccess)
                return EndpointResponse<UpdateCountryResponseViewModel>.Failure(result.Message);

            var responseVm = result.Data.Adapt<UpdateCountryResponseViewModel>();

            return EndpointResponse<UpdateCountryResponseViewModel>.Success(responseVm, "Country updated successfully");
        }
    }
}
