using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Views;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.DepartmentManagement.Common.Queries
{
    public record CheckDepartmentExistOnBranchQuery(string Name , string BranchId) : IRequest<RequestResult<bool>>;

    public class CheckDepartmentExistOnBranchQueryHandler : RequestHandlerBase<CheckDepartmentExistOnBranchQuery, RequestResult<bool>, Department>
    {
        public CheckDepartmentExistOnBranchQueryHandler(RequestHandlerBaseParameters<Department> parameters) : base(parameters)
        {
        }
        public async override Task<RequestResult<bool>> Handle(CheckDepartmentExistOnBranchQuery request, CancellationToken cancellationToken)
        {
            var departmentExists = await _repository.IsExistsAsync(d => d.Name.Trim().ToLower() == request.Name.Trim().ToLower() && d.BranchId == request.BranchId , cancellationToken);

            return RequestResult<bool>.Success(departmentExists);
        }
    }
}
