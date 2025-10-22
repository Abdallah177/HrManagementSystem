using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Views;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.BranchManagement.Common.Queries.CheckBranchExists
{
    public record CheckBranchExistsQuery(string BranchId): IRequest<RequestResult<bool>>;

    public class CheckBranchExistsQueryHandler : RequestHandlerBase<CheckBranchExistsQuery, RequestResult<bool>,Branch>
    {
        public CheckBranchExistsQueryHandler(RequestHandlerBaseParameters<Branch> parameters) : base(parameters)
        {
        }
        public async override Task<RequestResult<bool>> Handle(CheckBranchExistsQuery request, CancellationToken cancellationToken)
        {
            var branchExists = await _repository.IsExistsAsync(b => b.Id == request.BranchId);

            return RequestResult<bool>.Success(branchExists);
        }
    }
}
