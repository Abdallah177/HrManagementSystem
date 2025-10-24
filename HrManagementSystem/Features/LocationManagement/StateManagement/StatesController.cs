using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.LocationManagement.StateManagement.GetAllCountry;
using HrManagementSystem.Features.LocationManagement.StateManagement.GetAllCountry.Queries;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.LocationManagement.StateManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("")]
        public async Task<EndpointResponse<IEnumerable<GetAllStatesViewModel>>> GetAll(CancellationToken cancellationToken)
        {
            var states = await _mediator.Send(new GetAllStatesQuery(cancellationToken));

            return states.Adapt<EndpointResponse<IEnumerable<GetAllStatesViewModel>>>();
        }
    }
}
