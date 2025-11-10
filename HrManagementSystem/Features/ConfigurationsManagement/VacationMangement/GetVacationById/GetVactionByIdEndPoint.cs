using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.ConfigurationsManagement.VacationMangement.GetVacationById.Queries;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.ConfigurationsManagement.VacationMangement.GetVacationById
{
    public class GetVactionByIdEndPoint : BaseEndPoint<GetVacationByIdRequestViewModel, GetVacationByIdResponseViewModel>
    {
        public GetVactionByIdEndPoint(EndpointBaseParameters<GetVacationByIdRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpGet]
        public async Task<EndpointResponse<GetVacationByIdResponseViewModel>> GetVacationById([FromQuery] GetVacationByIdRequestViewModel requestViewModel)
        {
            var validationResult = ValidateRequest(requestViewModel);
            if (!validationResult.IsSuccess)
            {
                return validationResult;
            }
            var result = await _mediator.Send(new GetVacationByIdQuery(requestViewModel.Id));
            if (!result.IsSuccess)
            {
                return EndpointResponse<GetVacationByIdResponseViewModel>.Failure(result.Message, result.ErrorCode);
            }
            var responseViewModel = result.Data.Adapt<GetVacationByIdResponseViewModel>();
            return EndpointResponse<GetVacationByIdResponseViewModel>.Success(responseViewModel);
        }
    }
}
