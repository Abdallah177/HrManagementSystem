using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.LocationManagement.StateManagement.UpdateState.Commands;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.LocationManagement.StateManagement.UpdateState
{
    public class UpdateStateEndpoint : BaseEndPoint<UpdateStateRequestViewModel, UpdateStateResponseViewModel>
    {
        public UpdateStateEndpoint(EndpointBaseParameters<UpdateStateRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpPut]
        public async Task<EndpointResponse<UpdateStateResponseViewModel>> UpdateState (UpdateStateRequestViewModel viewModel)
        {
            var result = await _mediator.Send(new UpdateStateCommand(viewModel.Id, viewModel.Name, viewModel.CountryId));

            if (!result.IsSuccess)
            {
                return EndpointResponse<UpdateStateResponseViewModel>.Failure(result.Message, result.ErrorCode);
            }

            var updateStateResponseViewModel = result.Data.Adapt<UpdateStateResponseViewModel>();

            return EndpointResponse<UpdateStateResponseViewModel>.Success(updateStateResponseViewModel);
        }
    }
}
