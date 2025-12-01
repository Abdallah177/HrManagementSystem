using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Features;
using HrManagementSystem.Common.Entities.FeatureSope;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.ConfigurationsManagement.ConfigurationScopeOrchestrator;
using HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.AddRequest.Command;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.AddRequest.RequestOrchestrator
{
    public class RequestAddRequestEndPoint : BaseEndPoint<AddRequestViewModel, bool>
    {
        public RequestAddRequestEndPoint(EndpointBaseParameters<AddRequestViewModel> parameters) : base(parameters)
        {
        }
        [HttpPost]
        public async Task<EndpointResponse<bool>> AddRequest(AddRequestViewModel assignConfig)
        {

            var addcommandDTO = await _mediator.Send(new AddRequestCommand(assignConfig.AddRequestCommand.Title,
                assignConfig.AddRequestCommand.Status,
                assignConfig.AddRequestCommand.Description,
                assignConfig.AddRequestCommand.UserId));

            if (!addcommandDTO.IsSuccess)
                return EndpointResponse<bool>.Failure(addcommandDTO.Message, addcommandDTO.ErrorCode);


            var v = await _mediator.Send(new ConfigurationScopeOrchestrator<RequestScope, Request>(assignConfig.ScopeViewModel, assignConfig.ConfigId));
            if (!v.IsSuccess)
                return EndpointResponse<bool>.Failure(v.Message, v.ErrorCode);

            return EndpointResponse<bool>.Success(true);
        }

    }
}
