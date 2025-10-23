using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using MediatR;

namespace HrManagementSystem.Features.LocationManagement.StateMangement.GetStateById.Queries
{
    public record GetStateByIdQuery(string Id) : IRequest<RequestResult<State?>>;


    public class GetStateByIdQueryHandler : RequestHandlerBase<GetStateByIdQuery, RequestResult<State?>, State>
    {
        public GetStateByIdQueryHandler(RequestHandlerBaseParameters<State> requestHandlerBaseParameters) : base(requestHandlerBaseParameters) { }

        public override async Task<RequestResult<State?>> Handle(GetStateByIdQuery request, CancellationToken cancellationToken)
        {
            var state = await _repository.GetByIDAsync(request.Id, cancellationToken);
            if (state == null)
                return RequestResult<State?>.Failure("State is not found", ErrorCode.StateNotFound);

            return RequestResult<State?>.Success(state);
        }
    }
}
