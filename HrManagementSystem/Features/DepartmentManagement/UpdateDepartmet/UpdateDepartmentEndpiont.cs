using HrManagementSystem.Common.Views;
using HrManagementSystem.Common;
using HrManagementSystem.Features.DepartmentManagement.UpdateDepartmetn.Commands;
using Microsoft.AspNetCore.Mvc;
using Mapster;

namespace HrManagementSystem.Features.DepartmentManagement.UpdateDepartmet
{
    public class UpdateDepartmentEndpoint
     : BaseEndPoint<UpdateDepartmentRequestViewModel, UpdateDepartmentResponseViewModel>
    {
        public UpdateDepartmentEndpoint(EndpointBaseParameters<UpdateDepartmentRequestViewModel> parameters)
            : base(parameters)
        {
        }

        [HttpPut]
        public async Task<EndpointResponse<UpdateDepartmentResponseViewModel>> UpdateDepartment(UpdateDepartmentRequestViewModel viewModel)
        {
            var validationResult = ValidateRequest(viewModel);
            if (!validationResult.IsSuccess)
            {
                return validationResult;
            }

            var command = new UpdateDepartmentCommand(
                viewModel.Id,
                viewModel.Name,
                viewModel.Description,
                viewModel.BranchId
            );

            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return EndpointResponse<UpdateDepartmentResponseViewModel>
                    .Failure(result.Message, result.ErrorCode);
            }

            var response = result.Data.Adapt<UpdateDepartmentResponseViewModel>();

            return EndpointResponse<UpdateDepartmentResponseViewModel>.Success(response);
        }
    }

}
