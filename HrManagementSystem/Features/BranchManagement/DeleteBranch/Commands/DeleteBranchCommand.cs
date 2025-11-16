using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.BranchManagement.DeleteBranch.Queries;
using HrManagementSystem.Features.Common.CheckExists;
using MediatR;

namespace HrManagementSystem.Features.BranchManagement.DeleteBranch.Commands
{
    public record DeleteBranchCommand (string Id , string UserId) : IRequest<RequestResult<bool>>;

    public class DeleteBranchCommandHandler : RequestHandlerBase<DeleteBranchCommand, RequestResult<bool>, Branch>
    {
        public DeleteBranchCommandHandler(RequestHandlerBaseParameters<Branch> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<bool>> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id, request.UserId ,cancellationToken);

            return RequestResult<bool>.Success(true , "Branch and all related data (departments and teams) deleted successfully");
        }
    }
}
