using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.CompanyManagement.DeleteCompany.Commands;
using HrManagementSystem.Features.CompanyManagement.DeleteCompany;
using Microsoft.AspNetCore.Mvc;
using HrManagementSystem.Features.DepartmentManagement.DeleteDepartment.Commands;

namespace HrManagementSystem.Features.DepartmentManagement.DeleteDepartment
{
    public class DeleteDepartmentEndPoint : BaseEndPoint<DeleteDepartmentRequestViewModel, bool>
    {
        public DeleteDepartmentEndPoint(EndpointBaseParameters<DeleteDepartmentRequestViewModel> parameters) : base(parameters)
        {
        }


        [HttpDelete]
        public async Task<EndpointResponse<bool>> DeleteDepartment([FromQuery] DeleteDepartmentRequestViewModel request)
        {
            var validationResult = ValidateRequest(request);
            if (!validationResult.IsSuccess)
                return validationResult;

            var result = await _mediator.Send(new DeleteDepartmentOrchestrator(request.DepartmentId, GetCurrentUserId().ToString()));
            return new EndpointResponse<bool>(result.Data, result.IsSuccess, result.Message, result.ErrorCode);
        }
    }
}
