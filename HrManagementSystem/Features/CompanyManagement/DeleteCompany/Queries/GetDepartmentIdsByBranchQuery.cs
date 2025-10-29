using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Views;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.CompanyManagement.DeleteCompany.Queries
{
    public record GetDepartmentIdsByBranchQuery(string branchId) : IRequest<RequestResult<List<string>>>;

    public class GetDepartmentIdsByBranchQueryHandler : RequestHandlerBase<GetDepartmentIdsByBranchQuery, RequestResult<List<string>>, Department>
    {
        public GetDepartmentIdsByBranchQueryHandler(RequestHandlerBaseParameters<Department> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<List<string>>> Handle(GetDepartmentIdsByBranchQuery request, CancellationToken cancellationToken)
        {
             var departmentIds = await _repository
            .Get(d => d.BranchId == request.branchId)
            .Select(d => d.Id)
            .ToListAsync(cancellationToken);

            return RequestResult<List<string>>.Success(departmentIds);
        }
    }
}
