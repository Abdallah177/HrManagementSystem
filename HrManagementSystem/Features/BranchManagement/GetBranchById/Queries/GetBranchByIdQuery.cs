using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.BranchManagement.GetBranchById.Queries.Dtos;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
            var branch = await _repository.Get(b => b.Id == request.BranchId)
                .ProjectToType<BranchDto>().FirstOrDefaultAsync(cancellationToken);


            if (branch == null)
                return RequestResult<BranchDto>.Failure("Branch not found", ErrorCode.BranchNotExist);

            return RequestResult<BranchDto>.Success(branch);
        }
    }

}
