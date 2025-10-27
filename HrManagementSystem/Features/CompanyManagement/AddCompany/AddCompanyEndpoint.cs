using HrManagementSystem.Common.Views;
using HrManagementSystem.Common;
using HrManagementSystem.Features.CompanyManagement.AddCompany.Commands;
using Microsoft.AspNetCore.Mvc;
using Mapster;

namespace HrManagementSystem.Features.CompanyManagement.AddCompany
{
    public class AddCompanyEndpoint
    : BaseEndPoint<AddCompanyRequestViewModel, AddCompanyResponseViewModel>
    {
        public AddCompanyEndpoint(EndpointBaseParameters<AddCompanyRequestViewModel> parameters)
            : base(parameters)
        {
        }

        [HttpPost]
        public async Task<EndpointResponse<AddCompanyResponseViewModel>> AddCompany(AddCompanyRequestViewModel viewModel)
        {
            var validationResult = ValidateRequest(viewModel);
            if (!validationResult.IsSuccess)
            {
                return validationResult;
            }

            var command = new AddCompanyCommand(
                viewModel.Name,
                viewModel.Email,
                viewModel.CountryId,
                viewModel.OrganizationId
            );

            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return EndpointResponse<AddCompanyResponseViewModel>
                    .Failure(result.Message, result.ErrorCode);
            }

            var response = result.Data.Adapt<AddCompanyResponseViewModel>();

            return EndpointResponse<AddCompanyResponseViewModel>.Success(response);
        }
    }

}
