using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.Common.CheckExists;
using MediatR;

namespace HrManagementSystem.Features.OrganizationManagement.DeleteOrganization.Commands
{
    public record DeleteOrganizationCommand(string OrganizationId, string currentUserId) : IRequest<RequestResult<bool>>;

    public class DeleteOrganizationCommandHandler : RequestHandlerBase<DeleteOrganizationCommand, RequestResult<bool>, Organization>
    {
        public DeleteOrganizationCommandHandler(RequestHandlerBaseParameters<Organization> parameters) : base(parameters)
        {
        }
        public async override Task<RequestResult<bool>> Handle(DeleteOrganizationCommand request, CancellationToken cancellationToken)
        {
            var isOrganizationExist = await _mediator.Send(new CheckExistsQuery<Organization>(request.OrganizationId));
            if (!isOrganizationExist)
                return RequestResult<bool>.Failure("Organization not found", ErrorCode.OrganizationNotExis);
            await _repository.DeleteAsync(request.OrganizationId, request.currentUserId, cancellationToken);
            return RequestResult<bool>.Success(true, "Organization deleted successfully");
        }
    }

}
