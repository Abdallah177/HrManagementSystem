using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.TeamManagement.AddTeam.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.TeamManagement.AddTeam
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddTeamController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        [HttpPost("")]
        public async Task<EndpointResponse<bool>> Add([FromBody] AddTeamViewModel addTeamViewModel)
        {
            var addTeamResult = await _mediator.Send(new AddTeamCommand(addTeamViewModel.Name, addTeamViewModel.DepartmentId));

            return addTeamResult;
        }
    }
}
