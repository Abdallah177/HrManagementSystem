using HrManagementSystem.Common;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.LocationManagement.CityManagement.Queries.GetAllCities.Queries;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.LocationManagement.CityManagement.Queries.GetAllCities
{
    public class GetAllCitiesEndPoint : BaseEndPoint<object, List<GetAllCitiesResponseViewModel>>
    {
        public GetAllCitiesEndPoint(EndpointBaseParameters<object> parameters) : base(parameters)
        {
        }

        [HttpGet]
        public async Task<EndpointResponse<List<GetAllCitiesResponseViewModel>>> GetAllCities()
        {
            var result = await _mediator.Send(new GetAllCitiesQuery());
            if (!result.IsSuccess)
                return new EndpointResponse<List<GetAllCitiesResponseViewModel>>(default, false, result.Message, result.ErrorCode);

            var citiesData = result.Data.Adapt<List<GetAllCitiesResponseViewModel>>();
            return EndpointResponse<List<GetAllCitiesResponseViewModel>>.Success(citiesData);
        }
    }
}
