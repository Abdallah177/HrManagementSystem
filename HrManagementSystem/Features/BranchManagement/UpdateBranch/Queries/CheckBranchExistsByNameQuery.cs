using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.BranchManagement.UpdateBranch.Queries
{
    public record CheckBranchExistsByNameQuery (string Name) : IRequest<bool>;

    public class CheckBranchExistsByNameQueryHandler : RequestHandlerBase<CheckBranchExistsByNameQuery, bool, Branch>
    {
        public CheckBranchExistsByNameQueryHandler(RequestHandlerBaseParameters<Branch> parameters)
            : base(parameters)
        {
        }
        public override async Task<bool> Handle(CheckBranchExistsByNameQuery request, CancellationToken cancellationToken)
        {
            var normalizedName = request.Name.Trim().ToLower();

            var isDuplicate = await _repository.Get(b => b.Name.ToLower() == normalizedName).AnyAsync(cancellationToken);
            return isDuplicate;

        }
    }


}
