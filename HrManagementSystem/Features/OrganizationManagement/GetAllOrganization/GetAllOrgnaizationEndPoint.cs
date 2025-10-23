using HrManagementSystem.Common;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.OrganizationManagement.GetAllOrganization.Queries;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.OrganizationManagement.GetAllOrganization
{
    public class GetAllOrgnaizationEndPoint : BaseEndPoint<object, GetAllOrganizationResponseViewModel>
    {
        public GetAllOrgnaizationEndPoint(EndpointBaseParameters<object> parameters) : base(parameters)
        {
        }

        [HttpGet]
        public async Task<EndpointResponse<GetAllOrganizationResponseViewModel>> GetAllOrganizations()
        {
            var result = await _mediator.Send(new GetAllOrganizationsQuery());

            if (!result.IsSuccess)
                return new EndpointResponse<GetAllOrganizationResponseViewModel>(default, false, result.Message, result.ErrorCode);

            var organizationData = result.Data.Adapt<GetAllOrganizationResponseViewModel>();
            return EndpointResponse<GetAllOrganizationResponseViewModel>.Success(organizationData);

        }
    }
}
