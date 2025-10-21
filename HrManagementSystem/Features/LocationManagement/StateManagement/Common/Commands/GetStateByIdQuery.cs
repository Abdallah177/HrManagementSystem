using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.LocationManagement.StateManagement.Common.Dtos;
using Mapster;
using MediatR;

namespace HrManagementSystem.Features.LocationManagement.StateManagement.Common.Commands
{
    public record GetStateByIdQuery (string StateId) : IRequest<RequestResult<GetStateByIdDto>>;

    public class GetStateByIdQueryHandler : RequestHandlerBase<GetStateByIdQuery, RequestResult<GetStateByIdDto>, State>
    {
        public GetStateByIdQueryHandler(RequestHandlerBaseParameters<State> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<GetStateByIdDto>> Handle(GetStateByIdQuery request, CancellationToken cancellationToken)
        {
            var state = await _repository.GetByIDAsync(request.StateId);

            if (state == null)
                return RequestResult<GetStateByIdDto>.Failure("State Not Found", ErrorCode.StateNotFound);

            var getStateByIdDto = state.Adapt<GetStateByIdDto>();

            return RequestResult<GetStateByIdDto>.Success(getStateByIdDto);
        }
    }



}
