using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.LocationManagement.CityManagement.GetAllCities.Queries;
using HrManagementSystem.Features.LocationManagement.CityManagement.GetAllCities;
using HrManagementSystem.Features.LocationManagement.CountryManagement.Queries.GetAllCountries.Queries;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace HrManagementSystem.Features.LocationManagement.CountryManagement.Queries.GetAllCountries
{
    public class GetAllCountriesEndPoint : BaseEndPoint<object, List<GetAllCountriesViewModel>>
    {
        public GetAllCountriesEndPoint(EndpointBaseParameters<object> parameters) : base(parameters)
        {
        }

        [HttpGet]
        public async Task<EndpointResponse<List<GetAllCountriesViewModel>>> GetAllCountries(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllCountriesQuery(), cancellationToken);

            if (result.IsSuccess && result.Data != null)
            {

                var viewModels = result.Data.Adapt<List<GetAllCountriesViewModel>>();

                return EndpointResponse<List<GetAllCountriesViewModel>>.Success(viewModels, result.Message);
            }

            return EndpointResponse<List<GetAllCountriesViewModel>>.Failure(result.Message, result.ErrorCode);
        }

    }
}
