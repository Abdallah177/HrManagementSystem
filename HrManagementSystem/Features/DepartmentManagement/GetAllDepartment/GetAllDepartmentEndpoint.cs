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
        public async Task<EndpointResponse<GetAllDepartmentResponseViewModel>> GetAllDepartments()
        {
            var result = await _mediator.Send(new GetAllDepartmentQuery());
            if (!result.IsSuccess)
                return new EndpointResponse<GetAllDepartmentResponseViewModel>(default, false, result.Message, result.ErrorCode);
            var departmentData = result.Data.Adapt<GetAllDepartmentResponseViewModel>();
            return EndpointResponse<GetAllDepartmentResponseViewModel>.Success(departmentData);
        }
    }
}
