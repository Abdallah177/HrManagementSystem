using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.BranchManagement.Commands.AddBranch.DTOS;
using Mapster;
using MediatR;

namespace HrManagementSystem.Features.BranchManagement.Commands.AddBranch.Commands
{
    public record AddBranchCommand( string Name, string CityId, string? Phone, string CompanyId, string UserId): IRequest<RequestResult<AddBranchDTO>>;

    public class AddBranchCommandHandler : RequestHandlerBase<AddBranchCommand, RequestResult<AddBranchDTO>, Branch>
    {
        public AddBranchCommandHandler(RequestHandlerBaseParameters<Branch> parameters) : base(parameters)
        {
        }
        public override async Task<RequestResult<AddBranchDTO>> Handle(AddBranchCommand request, CancellationToken cancellationToken)
        {
            var branch = request.Adapt<Branch>();
            await _repository.AddAsync(branch, request.UserId, cancellationToken);
            var branchDto = branch.Adapt<AddBranchDTO>();
            return RequestResult<AddBranchDTO>.Success(branchDto);
        }
    }


}
