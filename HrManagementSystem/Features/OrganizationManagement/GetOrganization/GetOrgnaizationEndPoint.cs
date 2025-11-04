using HrManagementSystem.Common;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.OrganizationManagement.GetOrganization.Queries;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.OrganizationManagement.GetOrganization
{
    public class GetOrgnaizationEndPoint : BaseEndPoint<object, GetOrganizationResponseViewModel>
    {
        public GetOrgnaizationEndPoint(EndpointBaseParameters<object> parameters) : base(parameters)
        {
        }

        [HttpGet]
        public async Task<EndpointResponse<GetOrganizationResponseViewModel>> GetOrganizations()
        {
            var result = await _mediator.Send(new GetOrganizationsQuery());

            if (!result.IsSuccess)
                return new EndpointResponse<GetOrganizationResponseViewModel>(default, false, result.Message, result.ErrorCode);

            var organizationData = result.Data.Adapt<GetOrganizationResponseViewModel>();
            return EndpointResponse<GetOrganizationResponseViewModel>.Success(organizationData);

        }
    }
}
