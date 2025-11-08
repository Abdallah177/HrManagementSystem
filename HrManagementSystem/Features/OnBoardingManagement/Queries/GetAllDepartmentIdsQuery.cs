using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Branch;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Department;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.OnBoardingManagement.Queries
{
    public record GetAllDepartmentIdsQuery(List<string> branches) :IRequest<RequestResult<List<GetDepartmentIdsWithBrachIds>>>;
    public class GetAllDepartmentIdsQueryHandler : RequestHandlerBase<GetAllDepartmentIdsQuery, RequestResult<List<GetDepartmentIdsWithBrachIds>>, Department>
    {
        public GetAllDepartmentIdsQueryHandler(RequestHandlerBaseParameters<Department> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<List<GetDepartmentIdsWithBrachIds>>> Handle(GetAllDepartmentIdsQuery request, CancellationToken cancellationToken)
        {
            var departments = await _repository
             .Get(d => request.branches.Select(b => b).Contains(d.BranchId))
             .Select(d => new GetDepartmentIdsWithBrachIds 
             { 
                departmentId = d.Id,
                branchId = d.BranchId,
             })
             .ToListAsync(cancellationToken);

            return RequestResult<List<GetDepartmentIdsWithBrachIds>>.Success(departments);
        }
    }
}
