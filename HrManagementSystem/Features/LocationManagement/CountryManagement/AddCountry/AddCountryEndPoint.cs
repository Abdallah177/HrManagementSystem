using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.LocationManagement.CityManagement.AddCity;
using HrManagementSystem.Features.LocationManagement.CityManagement.AddCity.Commands;
using HrManagementSystem.Features.LocationManagement.CountryManagement.Commands.AddCountry;
using HrManagementSystem.Features.LocationManagement.CountryManagement.Commands.AddCountry.Commands;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.LocationManagement.CountryManagement.AddCountry
{
    public class AddCountryEndPoint : BaseEndPoint<AddCountryViewModel, bool>
    {
        public AddCountryEndPoint(EndpointBaseParameters<AddCountryViewModel> parameters) : base(parameters)
        {
        }
        [HttpPost]
        public async Task<EndpointResponse<bool>> AddCountry(AddCountryViewModel viewModel, CancellationToken cancellationToken)
        {
            var validationResult = ValidateRequest(viewModel);
            if (!validationResult.IsSuccess)
            {
                return validationResult;
            }

            var result = await _mediator.Send(new AddCountryCommand(viewModel.Name ,viewModel.Code ,GetCurrentUserId().ToString()), cancellationToken);

            if (!result.IsSuccess)
                return EndpointResponse<bool>.Failure(result.Message, result.ErrorCode);

            return EndpointResponse<bool>.Success(result.Data , result.Message);
        }
    }
}
