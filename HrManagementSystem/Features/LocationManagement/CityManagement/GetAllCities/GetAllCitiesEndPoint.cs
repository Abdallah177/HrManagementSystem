using HrManagementSystem.Common;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.LocationManagement.CityManagement.GetAllCities.Queries;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.LocationManagement.CityManagement.GetAllCities
{
    public class GetAllCitiesEndPoint : BaseEndPoint<GetAllCitiesQuery, List<GetAllCitiesResponseViewModel>>
    {
        public GetAllCitiesEndPoint(EndpointBaseParameters<GetAllCitiesQuery> parameters) : base(parameters)
        {
        }

        [HttpGet]
        public async Task<EndpointResponse<List<GetAllCitiesResponseViewModel>>> GetAllCities()
        {
            var cities = await _mediator.Send(new GetAllCitiesQuery());
            var result = cities.Data.Adapt<List<GetAllCitiesResponseViewModel>>();
            return EndpointResponse<List<GetAllCitiesResponseViewModel>>.Success(result);
        }
    }
}
