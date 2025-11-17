using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.ConfigurationsManagement.BreakManageMent.GetBreakById.Queries;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.ConfigurationsManagement.BreakManageMent.GetBreakById
{
    public class GetBreakByIdEndpoint : BaseEndPoint<GetBreakByIdRequestViewModel, GetBreakByIdResponseViewModel>
    {
        public GetBreakByIdEndpoint(EndpointBaseParameters<GetBreakByIdRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpGet]
        public async Task<EndpointResponse<GetBreakByIdResponseViewModel>> GetBreakById ([FromQuery]GetBreakByIdRequestViewModel viewModel)
        {
            var response =await _mediator.Send(new GetBreakByIdQuery(viewModel.Id));

            if (!response.IsSuccess)
                return EndpointResponse<GetBreakByIdResponseViewModel>.Failure(response.Message, response.ErrorCode);

            var requestViewModel = response.Data.Adapt<GetBreakByIdResponseViewModel>();

            return EndpointResponse<GetBreakByIdResponseViewModel>.Success(requestViewModel);
        }
    }
}
