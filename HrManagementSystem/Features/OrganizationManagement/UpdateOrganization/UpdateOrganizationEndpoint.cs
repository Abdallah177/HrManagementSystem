using HrManagementSystem.Common.Views;
using HrManagementSystem.Common;
using HrManagementSystem.Features.OrganizationManagement.NewFolder.Commands;
using Microsoft.AspNetCore.Mvc;
using Mapster;

namespace HrManagementSystem.Features.OrganizationManagement.UpdateOrganization
{
    public class UpdateOrganizationEndpoint
    : BaseEndPoint<UpdateOrganizationRequestViewModel, UpdateOrganizationResponseViewModel>
    {
        public UpdateOrganizationEndpoint(EndpointBaseParameters<UpdateOrganizationRequestViewModel> parameters)
            : base(parameters)
        {
        }

        [HttpPut]
        public async Task<EndpointResponse<UpdateOrganizationResponseViewModel>> UpdateOrganization(
            UpdateOrganizationRequestViewModel viewModel)
        {
            var command = new UpdateOrganizationCommand(
                viewModel.Id,
                viewModel.Name
            );

            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return EndpointResponse<UpdateOrganizationResponseViewModel>
                    .Failure(result.Message, result.ErrorCode);
            }

            var response = result.Data.Adapt<UpdateOrganizationResponseViewModel>();

            return EndpointResponse<UpdateOrganizationResponseViewModel>.Success(response);
        }
    }
}
