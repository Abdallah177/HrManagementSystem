using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Views;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.CompanyManagement.DeleteCompany.Queries
{
    public record GetBranchIdsByCompanyQuery(string companyId): IRequest<RequestResult<List<string>>>;
    public class GetBranchIdsByCompanyQueryHandler : RequestHandlerBase<GetBranchIdsByCompanyQuery, RequestResult<List<string>>, Branch>
    {
        public GetBranchIdsByCompanyQueryHandler(RequestHandlerBaseParameters<Branch> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<List<string>>> Handle(GetBranchIdsByCompanyQuery request, CancellationToken cancellationToken)
        {
            var branchIds = await _repository
                .Get(b => b.CompanyId == request.companyId)
                .Select(r => r.Id)
                .ToListAsync(cancellationToken);
            return RequestResult<List<string>>.Success(branchIds);
        }
    }
}
