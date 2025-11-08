using HrManagementSystem.Common.Entities.FeatureSope;
using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.OnBoardingManagement.Commands.GenerateScope;
using MediatR;
using HrManagementSystem.Common.Entities;
using Microsoft.EntityFrameworkCore;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Branch;

namespace HrManagementSystem.Features.OnBoardingManagement.Queries
{
    public record GetAllBranchIdsQuery(List<string> companyIds) : IRequest<RequestResult<List<GetBranchIdsWithCompanyIdsDto>>>;
    public class GetAllBranchIdsQueryHandler : RequestHandlerBase<GetAllBranchIdsQuery, RequestResult<List<GetBranchIdsWithCompanyIdsDto>>, Branch>
    {
        public GetAllBranchIdsQueryHandler(RequestHandlerBaseParameters<Branch> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<List<GetBranchIdsWithCompanyIdsDto>>> Handle(GetAllBranchIdsQuery request, CancellationToken cancellationToken)
        {
            var branches = await _repository
            .Get(b => request.companyIds.Contains(b.CompanyId))
            .Select(b => new GetBranchIdsWithCompanyIdsDto 
            { 
                branchId = b.Id,
                companyId = b.CompanyId
            })
            .ToListAsync(cancellationToken);

            return RequestResult<List<GetBranchIdsWithCompanyIdsDto>>.Success(branches);

        }
    }

}
