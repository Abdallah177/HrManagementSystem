using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.CompanyManagement.DeleteCompany.Commands;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.CompanyManagement.DeleteCompany
{
    public class DeleteCompanyEndPoint : BaseEndPoint<DeleteCompanyRequestViewModel, bool>
    {
        public DeleteCompanyEndPoint(EndpointBaseParameters<DeleteCompanyRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpDelete]
        public async Task<EndpointResponse<bool>> DeleteCompany([FromQuery] DeleteCompanyRequestViewModel request)
        {
            var validationResult = ValidateRequest(request);
            if (!validationResult.IsSuccess)
                return validationResult;

            var result = await _mediator.Send(new DeleteCompanyOrchestrator(request.CompanyId , GetCurrentUserId().ToString()));
            return new EndpointResponse<bool>(result.Data, result.IsSuccess, result.Message, result.ErrorCode);
        }
    }
}
