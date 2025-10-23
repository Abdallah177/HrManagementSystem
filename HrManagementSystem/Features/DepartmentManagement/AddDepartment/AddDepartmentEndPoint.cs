using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.DepartmentManagement.AddDepartment.Commands;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.DepartmentManagement.AddDepartment
{
    public class AddDepartmentEndPoint : BaseEndPoint<AddDepartmentRequestViewModel, bool>
    {
        public AddDepartmentEndPoint(EndpointBaseParameters<AddDepartmentRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpPost]
        public async Task<EndpointResponse<bool>> AddDepartment([FromBody] AddDepartmentRequestViewModel requestVM)
        {
            var validationResult = ValidateRequest(requestVM);
            if (!validationResult.IsSuccess)
                return validationResult;

            var departmentCommand = requestVM.Adapt<AddDepartmentCommand>();
            departmentCommand = departmentCommand with { currentUserId = GetCurrentUserId().ToString() };

            var result = await _mediator.Send(departmentCommand);
            return new EndpointResponse<bool>(result.Data, result.IsSuccess, result.Message, result.ErrorCode);
        }
    }
}
