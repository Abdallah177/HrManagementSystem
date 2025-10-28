using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.DepartmentManagement.GetAllDepartment.Queries;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.DepartmentManagement.GetAllDepartment
{
    public class GetAllDepartmentEndpoint : BaseEndPoint<object, GetAllDepartmentResponseViewModel>
    {
        public GetAllDepartmentEndpoint(EndpointBaseParameters<object> parameters) : base(parameters)
        {
        }

        [HttpGet]
        public async Task<EndpointResponse<List<GetAllDepartmentResponseViewModel>>> GetAllDepartments([FromQuery] GetAllDepartmentRequestViewModel request)
        {
            var result = await _mediator.Send(new GetAllDepartmentQuery(request.BranchId));
            if (!result.IsSuccess)
                return new EndpointResponse<List<GetAllDepartmentResponseViewModel>>(default, false, result.Message, result.ErrorCode);

            var departmentData = result.Data.Adapt<List<GetAllDepartmentResponseViewModel>>();
            return EndpointResponse<List<GetAllDepartmentResponseViewModel>>.Success(departmentData);
        }
    }
}
