using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.OrganizationManagement.AddOrganization.Commands;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.OrganizationManagement.AddOrganization
{
    public class AddOrganizationEndPoint : BaseEndPoint<AddOrganizationRequestViewModle, string>
    {
        public AddOrganizationEndPoint(EndpointBaseParameters<AddOrganizationRequestViewModle> parameters) : base(parameters)
        {
        }

        [HttpPost]
        public async Task<EndpointResponse<string>> AddOrganization([FromBody] AddOrganizationRequestViewModle request)
        {
            var validation = ValidateRequest(request);
            if (!validation.IsSuccess)
                return validation;

            var UserId = GetCurrentUserId().ToString();
            var res= await _mediator.Send(new AddOrganizationCommand(request.Name, UserId));

            return new EndpointResponse<string>(res.Data, res.IsSuccess, res.Message, res.ErrorCode);

        }
    }
}
