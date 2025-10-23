using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.LocationManagement.CountryManagement.AddCountry.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.LocationManagement.CountryManagement.Commands.AddCountry
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddNewCountryController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("")]
        public async Task<EndpointResponse<bool>> Add([FromBody] AddCountryViewModel addCountryView, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new AddCountryCommand(addCountryView.Name, addCountryView.Code, addCountryView.UserId), cancellationToken);

            return result;
        }
    }
}
