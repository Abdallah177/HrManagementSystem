using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Views;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace HrManagementSystem.Features.BranchManagement.GetAllBranches.Queries
{
    public record GetAllBranchesQuery() : IRequest<RequestResult<List<GetAllBranchesResponseViewModel>>>;

    public class GetAllBranchesQueryHandler : RequestHandlerBase<GetAllBranchesQuery, RequestResult<List<GetAllBranchesResponseViewModel>>, Branch>
    {
        public GetAllBranchesQueryHandler(RequestHandlerBaseParameters<Branch> parameters) : base(parameters)
        {
        }
        public async override Task<RequestResult<List<GetAllBranchesResponseViewModel>>> Handle(GetAllBranchesQuery request, CancellationToken cancellationToken)
        {
            var branches = await _repository.GetAll()
                .ProjectToType<GetAllBranchesResponseViewModel>()
                .ToListAsync(cancellationToken);
            return RequestResult<List<GetAllBranchesResponseViewModel>>.Success(branches);
        }
    }
}
    
