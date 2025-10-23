using HrManagementSystem.Common;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using MediatR;

namespace HrManagementSystem.Features.LocationManagement.StateManagement.DeleteState.Commands
{
    public record DeleteStateCommand(string stateId, string currentUserId) : IRequest<RequestResult<bool>>;

    public class DeleteStateCommandHandler
        : RequestHandlerBase<DeleteStateCommand, RequestResult<bool>, HrManagementSystem.Common.Entities.Location.State>
    {
        public DeleteStateCommandHandler(
            RequestHandlerBaseParameters<HrManagementSystem.Common.Entities.Location.State> parameters
        ) : base(parameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(DeleteStateCommand request, CancellationToken cancellationToken)
        {
            var stateExistsResult = await _mediator.Send(new Queries.CheckStateExistsQuery(request.stateId), cancellationToken);
            if (!stateExistsResult.Data)
                return RequestResult<bool>.Failure("State not found", ErrorCode.StateNotFound);

            var hasCitiesResult = await _mediator.Send(new Queries.CheckStateHasCitiesQuery(request.stateId), cancellationToken);
            if (hasCitiesResult.Data)
                return RequestResult<bool>.Failure("State related with City", ErrorCode.StateHasCities);

            await _repository.DeleteAsync(request.stateId, request.currentUserId, cancellationToken);
            return RequestResult<bool>.Success(true, "State deleted successfully");
        }
    }
}
