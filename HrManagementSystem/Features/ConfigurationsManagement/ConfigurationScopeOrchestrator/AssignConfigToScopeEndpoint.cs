using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Features;
using HrManagementSystem.Common.Entities.FeatureSope;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.ConfigurationsManagement.ConfigurationScopeOrchestrator.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.ConfigurationsManagement.ConfigurationScopeOrchestrator
{
    public class AssignConfigToScopeEndpoint : BaseEndPoint<AssignConfigRequest, bool>
    {
        public AssignConfigToScopeEndpoint(EndpointBaseParameters<AssignConfigRequest> parameters) : base(parameters)
        {
        }

        [HttpPost]
        public async Task<EndpointResponse<bool>> AssignConfigToScope(AssignConfigRequest assignConfig)
        {
            var v =await _mediator.Send(new ConfigurationScopeOrchestrator<ShiftScope, Shift>(assignConfig.ScopeViewModel, assignConfig.ConfigId));

            if (!v.IsSuccess)
                return EndpointResponse<bool>.Failure(v.Message, v.ErrorCode);

            return EndpointResponse<bool>.Success(true);
        }
    }
}
