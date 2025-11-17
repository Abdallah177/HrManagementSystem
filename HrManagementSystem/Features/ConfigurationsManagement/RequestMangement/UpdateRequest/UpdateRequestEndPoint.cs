using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.UpdateRequest.Commands;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.UpdateRequest
{
    public class UpdateRequestEndPoint : BaseEndPoint<UpdateRequestRequestViewModel, UpdateRequestResponseViewModel>
    {
        public UpdateRequestEndPoint(EndpointBaseParameters<UpdateRequestRequestViewModel> parameters) : base(parameters)
        {
        }
        [HttpPut]
        public async Task<EndpointResponse<UpdateRequestResponseViewModel>> UpdateRequest(UpdateRequestRequestViewModel viewModel)
        {
            var command = new UpdateRequestCommand(
                viewModel.Id,
                viewModel.Title,
                viewModel.Description,
                viewModel.Status
            );
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return EndpointResponse<UpdateRequestResponseViewModel>
                    .Failure(result.Message, result.ErrorCode);
            }

            var response = result.Data.Adapt<UpdateRequestResponseViewModel>();

            return EndpointResponse<UpdateRequestResponseViewModel>.Success(response);
        }   
    }
}
