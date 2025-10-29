using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.BranchManagement.DeleteBranch.Queries
{
    public record CheckIfBranchHaveAnyDepartment (string BranchId) : IRequest<bool>;

    public class CheckIfBranchHaveAnyDepartmentHandler : RequestHandlerBase<CheckIfBranchHaveAnyDepartment, bool, Department>
    {
        public CheckIfBranchHaveAnyDepartmentHandler(RequestHandlerBaseParameters<Department> parameters) : base(parameters)
        {
        }

        public override async Task<bool> Handle(CheckIfBranchHaveAnyDepartment request, CancellationToken cancellationToken)
        {
            var result = await _repository.Get(D => D.BranchId == request.BranchId).AnyAsync();

            return result;  
        }
    }


}
