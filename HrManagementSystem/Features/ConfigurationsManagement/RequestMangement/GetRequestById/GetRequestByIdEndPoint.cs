using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.GetRequestById.Query;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.GetRequestById
{
    public class GetRequestByIdEndPoint : BaseEndPoint<GetRequestByIdRequesViewModel, GetRequestByIdResponseViewModel>
    {
        public GetRequestByIdEndPoint(EndpointBaseParameters<GetRequestByIdRequesViewModel> parameters) : base(parameters)
        {
        }
        [HttpGet("GetRequestById")]
        public async Task<EndpointResponse<GetRequestByIdResponseViewModel>> GetRequestById([FromQuery] GetRequestByIdRequesViewModel requestViewModel)
        {
            var validationResult = ValidateRequest(requestViewModel);

            if (!validationResult.IsSuccess)
            {
                return validationResult;
            }

            var result = await _mediator.Send(new GetRequestByIdQuery(requestViewModel.Id));

            if (!result.IsSuccess)
            {
                return EndpointResponse<GetRequestByIdResponseViewModel>.Failure(result.Message, result.ErrorCode);
            }

            var responseViewModel = result.Data.Adapt<GetRequestByIdResponseViewModel>();

            return EndpointResponse<GetRequestByIdResponseViewModel>.Success(responseViewModel);
        }
    }
}
