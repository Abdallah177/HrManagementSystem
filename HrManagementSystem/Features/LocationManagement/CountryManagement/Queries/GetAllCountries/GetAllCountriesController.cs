using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.LocationManagement.CountryManagement.GetAllCountries.Queries;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.LocationManagement.CountryManagement.Queries.GetAllCountries
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetAllCountriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetAllCountriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("")]
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
