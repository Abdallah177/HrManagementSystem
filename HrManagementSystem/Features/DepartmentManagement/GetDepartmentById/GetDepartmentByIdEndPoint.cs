using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.DepartmentManagement.GetDepartmentById.Query;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.DepartmentManagement.GetDepartmentById
{
    public class GetDepartmentByIdEndPoint : BaseEndPoint<GetDepartmentByIdRequestViewModel, GetDepartmentByIdResponseViewModel>
    {
        public GetDepartmentByIdEndPoint(EndpointBaseParameters<GetDepartmentByIdRequestViewModel> parameters) : base(parameters)
        {
        }
        [HttpGet]
        public async Task<EndpointResponse<GetDepartmentByIdResponseViewModel>> GetDepartmentById([FromQuery] GetDepartmentByIdRequestViewModel request)
        {
            var validationResponse = ValidateRequest(request);
            if (!validationResponse.IsSuccess)
                return EndpointResponse<GetDepartmentByIdResponseViewModel>.Failure(validationResponse.Message);
            var departmentQueryResult = await _mediator.Send(new GetDepartmentByIdQuery(request.Id));
            if (!departmentQueryResult.IsSuccess)
                return EndpointResponse<GetDepartmentByIdResponseViewModel>.Failure(departmentQueryResult.Message);
            var departmentData = departmentQueryResult.Data.Adapt<GetDepartmentByIdResponseViewModel>();
            return EndpointResponse<GetDepartmentByIdResponseViewModel>.Success(departmentData);
        }
  
    }
}
