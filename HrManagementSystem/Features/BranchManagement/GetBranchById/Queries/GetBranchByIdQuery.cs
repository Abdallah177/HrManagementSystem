using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.BranchManagement.GetBranchById.Queries.Dtos;
using Mapster;
using MediatR;

namespace HrManagementSystem.Features.BranchManagement.GetBranchById.Queries
{
    public record GetBranchByIdQuery(string BranchId) : IRequest<RequestResult<BranchDto>>;
    public class GetBranchByIdQueryHandler : RequestHandlerBase<GetBranchByIdQuery, RequestResult<BranchDto>, Branch>
    {
        public GetBranchByIdQueryHandler(RequestHandlerBaseParameters<Branch> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<BranchDto>> Handle(GetBranchByIdQuery request, CancellationToken cancellationToken)
        {
            var branch = await _repository.GetByIDAsync(request.BranchId ,cancellationToken);

            if (branch == null)
                return RequestResult<BranchDto>.Failure("Branch not found", ErrorCode.BranchNotFound);

            var branchData = branch.Adapt<BranchDto>();
            return RequestResult<BranchDto>.Success(branchData);
        }
    }

}
