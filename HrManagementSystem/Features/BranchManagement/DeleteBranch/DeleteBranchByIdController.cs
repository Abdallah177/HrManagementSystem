using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.BranchManagement.DeleteBranch.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.BranchManagement.DeleteBranch
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteBranchByIdController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpDelete]
        public async Task<EndpointResponse<bool>> Delete([FromBody] DeleteBranchByIdViewModel deleteBranchByIdView)
        {
            var result = await _mediator.Send(new DeleteBrnachByIdCommand(deleteBranchByIdView.Id));

            return result;
        }
    }
}
