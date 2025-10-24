using HrManagementSystem.Common.Views;
using HrManagementSystem.Common;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using HrManagementSystem.Features.CompanyManagement.UpdateCompany.Commands;

namespace HrManagementSystem.Features.CompanyManagement.UpdateCompany
{
    public class UpdateCompanyEndpoint : BaseEndPoint<UpdateCompanyRequestViewModel, UpdateCompanyResponseViewModel>
    {
        public UpdateCompanyEndpoint(EndpointBaseParameters<UpdateCompanyRequestViewModel> parameters)
            : base(parameters)
        {
        }

        [HttpPut]
        public async Task<EndpointResponse<UpdateCompanyResponseViewModel>> UpdateCompany(UpdateCompanyRequestViewModel viewModel)
        {
            var command = new UpdateCompanyCommand(
            viewModel.Id,
            viewModel.Name,
            viewModel.Email,
            viewModel.CountryId,
            viewModel.OrganizationId
        );

            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return EndpointResponse<UpdateCompanyResponseViewModel>
                    .Failure(result.Message, result.ErrorCode);
            }

            var response = result.Data.Adapt<UpdateCompanyResponseViewModel>();

            return EndpointResponse<UpdateCompanyResponseViewModel>.Success(response);
        }
    }

}
