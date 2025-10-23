using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.LocationManagement.CityManagement.Commands.AddCity.Commands;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.LocationManagement.CityManagement.Commands.AddCity
{
    public class AddCityEndpoint : BaseEndPoint<AddCityRequestViewModel, AddCityResponseViewModel>
    {
        public AddCityEndpoint(EndpointBaseParameters<AddCityRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpPost]
        public async Task<EndpointResponse<AddCityResponseViewModel>> AddCity (AddCityRequestViewModel viewModel , CancellationToken cancellationToken)
        {
            var validationResult = ValidateRequest(viewModel);
            if (!validationResult.IsSuccess)
            {
                return validationResult;
            }

            var result = await _mediator.Send(new AddCityCommand(viewModel.Name, viewModel.StateId, viewModel.UserId));

            if (!result.IsSuccess)
                return EndpointResponse<AddCityResponseViewModel>.Failure(result.Message, result.ErrorCode);

            var addCityResponseViewModel = result.Data.Adapt<AddCityResponseViewModel>();

            return EndpointResponse<AddCityResponseViewModel>.Success(addCityResponseViewModel);
        }

    }
}
