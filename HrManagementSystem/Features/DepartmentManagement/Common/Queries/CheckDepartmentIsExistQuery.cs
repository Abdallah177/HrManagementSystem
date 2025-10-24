using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Views;
using MediatR;

namespace HrManagementSystem.Features.DepartmentManagement.Common.Queries
{
    public record CheckDepartmentIsExistQuery(string DepartmentId) : IRequest<RequestResult<bool>>;
    
    public class CheckDepartmentIsExistQueryHandler : RequestHandlerBase<CheckDepartmentIsExistQuery, RequestResult<bool>, Department>
    {
        public CheckDepartmentIsExistQueryHandler(RequestHandlerBaseParameters<Department> parameters) : base(parameters)
        {
        }
        public async override Task<RequestResult<bool>> Handle(CheckDepartmentIsExistQuery request, CancellationToken cancellationToken)
        {
            var departmentExists = await _repository.IsExistsAsync(d => d.Id == request.DepartmentId);

            return RequestResult<bool>.Success(departmentExists);
        }
    }
}
