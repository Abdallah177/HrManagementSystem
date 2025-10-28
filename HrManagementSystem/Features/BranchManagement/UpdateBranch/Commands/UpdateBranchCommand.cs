using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.BranchManagement.GetBranchById.Queries;
using HrManagementSystem.Features.BranchManagement.UpdateBranch.DTOs;
using HrManagementSystem.Features.BranchManagement.UpdateBranch.Queries;
using Mapster;
using MediatR;

namespace HrManagementSystem.Features.BranchManagement.UpdateBranch.Commands
{
    public record UpdateBranchCommand(string Id, string Name, string? Phone, string CompanyId, string CityId)
        :IRequest<RequestResult<UpdateBranchDto>>;

    public class UpdateBranchCommandHandler : RequestHandlerBase<UpdateBranchCommand, RequestResult<UpdateBranchDto>, Branch>
    {
        public UpdateBranchCommandHandler(RequestHandlerBaseParameters<Branch> parameters)
            : base(parameters)
        {
        }
        public override async Task<RequestResult<UpdateBranchDto>> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
        {
            
            var branch = await _repository.GetByIDAsync(request.Id, cancellationToken);
            if (branch is null)
                return RequestResult<UpdateBranchDto>.Failure("Branch Not Found", ErrorCode.BranchNotFound);

           
            var isDuplicate = await _mediator.Send(new CheckBranchExistsByNameQuery(request.Name));
            if (isDuplicate)
                return RequestResult<UpdateBranchDto>.Failure("Branch Name Already Exists", ErrorCode.DuplicateRecord);

            request.Adapt(branch);

            await _repository.UpdateIncludeAsync(
                branch, request.Id,
                cancellationToken,
                nameof(Branch.Name),
                nameof(Branch.Phone),
                nameof(Branch.CompanyId),
                nameof(Branch.CityId)
            );

            var dto = branch.Adapt<UpdateBranchDto>();
            return RequestResult<UpdateBranchDto>.Success(dto);
        }


    }

}

