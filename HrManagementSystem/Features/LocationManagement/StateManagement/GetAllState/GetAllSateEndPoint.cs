using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.LocationManagement.StateManagement.GetAllState.Query;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.LocationManagement.StateManagement.GetAllState
{
    public class GetAllSateEndPoint : BaseEndPoint<object, GetAllStateResponseViewModel>
    {
        public GetAllSateEndPoint(EndpointBaseParameters<object> parameters) : base(parameters)
        {
        }
        [HttpGet]
        public async Task<EndpointResponse<GetAllStateResponseViewModel>> GetAllStates()
        {
            var result = await _mediator.Send(new GetAllStateQuery());

            if (!result.IsSuccess)
                return new EndpointResponse<GetAllStateResponseViewModel>(default, false, result.Message, result.ErrorCode);

            var stateData = result.Data.Adapt<GetAllStateResponseViewModel>();

            return EndpointResponse<GetAllStateResponseViewModel>.Success(stateData);
        }
    }
}
