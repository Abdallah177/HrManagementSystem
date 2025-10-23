using Azure.Core;
using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.LocationManagement.CountryManagement.GetCountryById;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using HrManagementSystem.Features.LocationManagement.CountryManagement.GetByIdCountry.Queries;

namespace HrManagementSystem.Features.LocationManagement.CountryManagement.GetByIdCountry
{
    public class GetCountryByIdEndpoint : BaseEndPoint<GetCountryByIdRequestViewModel, GetCountryByIdResponseViewModel>
    {
        public GetCountryByIdEndpoint(EndpointBaseParameters<GetCountryByIdRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpGet]
        public async Task<EndpointResponse<GetCountryByIdResponseViewModel>> GetCountryById([FromQuery]GetCountryByIdRequestViewModel requestViewModel)
        {
            var validationResult = ValidateRequest(requestViewModel);
            if (!validationResult.IsSuccess)
            {
                return validationResult;
            }

            var result = await _mediator.Send(new GetCountryByIdQuery(requestViewModel.Id));

            if (!result.IsSuccess)
            {
                return EndpointResponse<GetCountryByIdResponseViewModel>.Failure(result.Message, result.ErrorCode);
            }

            var responseViewModel = result.Data.Adapt<GetCountryByIdResponseViewModel>();   

            return EndpointResponse<GetCountryByIdResponseViewModel>.Success(responseViewModel);
        }
    }
}
