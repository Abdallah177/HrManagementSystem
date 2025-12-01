using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.ConfigurationsManagement.ShiftManagement.GetShiftId.Queries;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.ConfigurationsManagement.ShiftManagement.GetShiftId
{
    public class GetShiftByIdEndpoint
    : BaseEndPoint<GetShiftByIdRequestViewModel, GetShiftByIdResponseViewModel>
    {
        public GetShiftByIdEndpoint(EndpointBaseParameters<GetShiftByIdRequestViewModel> parameters)
            : base(parameters)
        {
        }

        [HttpGet]
        public async Task<EndpointResponse<GetShiftByIdResponseViewModel>> GetShiftById(
            [FromQuery] GetShiftByIdRequestViewModel viewModel)
        {
            var response = await _mediator.Send(new GetShiftByIdQuery(viewModel.Id));


            if (!response.IsSuccess)
                return EndpointResponse<GetShiftByIdResponseViewModel>
                    .Failure(response.Message, response.ErrorCode);

            var responseViewModel = response.Data.Adapt<GetShiftByIdResponseViewModel>();


            return EndpointResponse<GetShiftByIdResponseViewModel>.Success(responseViewModel);
        }
    }

}
