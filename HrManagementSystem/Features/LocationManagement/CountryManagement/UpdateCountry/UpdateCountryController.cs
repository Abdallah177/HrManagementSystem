using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.LocationManagement.CountryManagement.UpdateCountry.Commands;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.LocationManagement.CountryManagement.UpdateCountry
{
    public class UpdateCountryController : BaseEndPoint<UpdateCountryRequestViewModle, UpdateCountryResponseViewModel>
    {
        public UpdateCountryController(EndpointBaseParameters<UpdateCountryRequestViewModle> parameters):base(parameters) { }


        [HttpPut]
        public async Task<EndpointResponse<UpdateCountryResponseViewModel>> UpdateCountry ([FromBody]UpdateCountryRequestViewModle request)
        {

            var validation = ValidateRequest(request);
            if (!validation.IsSuccess)
                return EndpointResponse<UpdateCountryResponseViewModel>.Failure(validation.Message);

            var command = request.Adapt<UdateCountryCommand>();
            command.UpdatedByUser = GetCurrentUserId().ToString();

            var countryUpdated = await _mediator.Send(command);

            if (!countryUpdated.IsSuccess)
                return EndpointResponse<UpdateCountryResponseViewModel>.Failure(countryUpdated.Message , countryUpdated.ErrorCode);

            var responseVm = countryUpdated.Data.Adapt<UpdateCountryResponseViewModel>();

            return EndpointResponse<UpdateCountryResponseViewModel>.Success(responseVm, "Country updated successfully");
        }
    }
}
