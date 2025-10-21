using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.LocationManagement.StateManagement.AddState.Commands;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.LocationManagement.StateManagement.AddState
{

    public class AddStateEndpoint : BaseEndPoint<AddStateRequestViewModel, bool>
    {
        public AddStateEndpoint(EndpointBaseParameters<AddStateRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpPost]
        public async Task<EndpointResponse<bool>> AddState([FromBody] AddStateRequestViewModel requestVM)
        {
            var validationResult = ValidateRequest(requestVM);
            if (!validationResult.IsSuccess)
                return validationResult;

            var stateCommand = requestVM.Adapt<AddStateCommand>();
            stateCommand = stateCommand with { currentUserId = GetCurrentUserId().ToString() }; 
            
            var result = await _mediator.Send(stateCommand);
            return new EndpointResponse<bool>(result.Data, result.IsSuccess, result.Message, result.ErrorCode);

        }
    }
}
