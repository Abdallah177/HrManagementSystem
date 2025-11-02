using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.LocationManagement.StateManagement.GetAllState.Query;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.LocationManagement.StateManagement.GetAllState
{
    public class GetAllSateEndPoint : BaseEndPoint<object, List<GetAllStateResponseViewModel>>
    {
        public GetAllSateEndPoint(EndpointBaseParameters<object> parameters) : base(parameters)
        {
        }
        [HttpGet]
        public async Task<EndpointResponse<List<GetAllStateResponseViewModel>>> GetAllStates()
        {
            var result = await _mediator.Send(new GetAllStateQuery());

            if (!result.IsSuccess)
                return new EndpointResponse<List<GetAllStateResponseViewModel>>(default, false, result.Message, result.ErrorCode);

            var stateData = result.Data.Adapt<List<GetAllStateResponseViewModel>>();

            return EndpointResponse<List<GetAllStateResponseViewModel>>.Success(stateData);
        }
    }
}
