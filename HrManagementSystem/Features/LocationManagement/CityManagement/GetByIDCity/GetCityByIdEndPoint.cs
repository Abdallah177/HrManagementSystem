using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.LocationManagement.CityManagement.GetByIDCity.Queries;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.LocationManagement.CityManagement.GetByIDCity
{
    public class GetCityByIdEndPoint : BaseEndPoint<GetCityByIdRequestViewModel, GetCityByIdResponseViewModel>
    {

        public GetCityByIdEndPoint(EndpointBaseParameters<GetCityByIdRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpGet ("")]
        public async Task<EndpointResponse<GetCityByIdResponseViewModel>> GetCityById([FromQuery] GetCityByIdRequestViewModel requestViewModel)
        {
            var validationResult = ValidateRequest(requestViewModel);
            if (!validationResult.IsSuccess)
            {
                return validationResult;
            }

            var result = await _mediator.Send(new GetCityByIdQuery(requestViewModel.Id));

            if (!result.IsSuccess)
            {
                return EndpointResponse<GetCityByIdResponseViewModel>.Failure(result.Message, result.ErrorCode);
            }

            var responseViewModel = result.Data.Adapt<GetCityByIdResponseViewModel>();

            return EndpointResponse<GetCityByIdResponseViewModel>.Success(responseViewModel);
        }
    }
}
