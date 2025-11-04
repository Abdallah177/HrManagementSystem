using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.OverTimeManagement.GetAll.Queries;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.OverTimeManagement.GetAll
{
    public class GetAllOverTimeEndpoint(EndpointBaseParameters<object> parameters) : BaseEndPoint<object,EndpointResponse<GetAllOverTimeViewModel>>(parameters)
    {
        [HttpGet("")]
        public async Task<EndpointResponse<GetAllOverTimeViewModel>> GetAll()
        {
            var response = await _mediator.Send(new GetAllOverTimeQuery());

            return EndpointResponse<GetAllOverTimeViewModel>.Success(response.Data.Adapt<GetAllOverTimeViewModel>());
        }
    }
}
