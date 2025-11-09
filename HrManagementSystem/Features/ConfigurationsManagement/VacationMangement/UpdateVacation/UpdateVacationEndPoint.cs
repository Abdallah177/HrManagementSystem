using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.ConfigurationsManagement.VacationMangement.UpdateVacation.Commands;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.ConfigurationsManagement.VacationMangement.UpdateVacation
{
    public class UpdateVacationEndPoint : BaseEndPoint<UpdateVacationRequestViewModel, UpdateVacationResponseViewModel>
    {
        public UpdateVacationEndPoint(EndpointBaseParameters<UpdateVacationRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpPut]
        public async Task<EndpointResponse<UpdateVacationResponseViewModel>> UpdateVacation(UpdateVacationRequestViewModel viewModel)
        {
            var command = new UpdateVacationCommand(
                viewModel.Id,
                viewModel.Name,
                viewModel.Type,
                viewModel.DurationInDays,
                viewModel.Description

            );
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return EndpointResponse<UpdateVacationResponseViewModel>
                    .Failure(result.Message, result.ErrorCode);
            }
            var response = result.Data.Adapt<UpdateVacationResponseViewModel>();
            return EndpointResponse<UpdateVacationResponseViewModel>.Success(response);
        }
    }
    
     
}
