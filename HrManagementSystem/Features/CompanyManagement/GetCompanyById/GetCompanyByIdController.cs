using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.CompanyManagement.GetCompanyById.Queries;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.CompanyManagement.GetCompanyById
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetCompanyByIdController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("")]
        public async Task<EndpointResponse<GetCompanyByIdViewModel>> Get([FromBody] string Id)
        {
            var GetCompanyResult = await _mediator.Send(new GetCompanyByIdQuery(Id));

            return GetCompanyResult.Adapt<EndpointResponse<GetCompanyByIdViewModel>>();
        }
    }
}
