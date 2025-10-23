using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Views;
using MediatR;

namespace HrManagementSystem.Features.CompanyManagement.Common.Query.CheckCompanyHasBranchs
{
    public record CheckCompanyHasBranchsQuery(string CompanyId) : IRequest<RequestResult<bool>>;

    public class CheckCompanyHasBranchsQueryHandler : RequestHandlerBase<CheckCompanyHasBranchsQuery, RequestResult<bool>,Branch>
    {
        public CheckCompanyHasBranchsQueryHandler(RequestHandlerBaseParameters<Branch> parameters) : base(parameters)
        {
        }
        public async override Task<RequestResult<bool>> Handle(CheckCompanyHasBranchsQuery request, CancellationToken cancellationToken)
        {
            var hasBranchs = await _repository.IsExistsAsync(b => b.CompanyId == request.CompanyId);
            return RequestResult<bool>.Success(hasBranchs);
        }
    }

}
