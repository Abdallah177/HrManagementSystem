

using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.Common.CheckExists;
using HrManagementSystem.Features.Common.Location.Country.CheckCountryExists;
using HrManagementSystem.Features.LocationManagement.StateManagement.Common.Commands;
using HrManagementSystem.Features.LocationManagement.StateManagement.UpdateState.Dtos;
using Mapster;
using MediatR;

namespace HrManagementSystem.Features.LocationManagement.StateManagement.UpdateState.Commands
{
    public record UpdateStateCommand (string StateId , string Name , string CountryId) : IRequest<RequestResult<StateDto>>;

    public class UpdateStateCommandHandler : RequestHandlerBase<UpdateStateCommand, RequestResult<StateDto>,State>
    {
        public UpdateStateCommandHandler(RequestHandlerBaseParameters<State> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<StateDto>> Handle(UpdateStateCommand request, CancellationToken cancellationToken)
        {

            var stateResponse = await _mediator.Send(new GetStateByIdQuery(request.StateId));
            if (!stateResponse.IsSuccess)
                return  RequestResult<StateDto>.Failure("State Not Found.", ErrorCode.StateNotFound);

            var IsCountryExist = await _mediator.Send(new CheckExistsQuery<Country>(request.CountryId));

            if (!IsCountryExist)
                return RequestResult<StateDto>.Failure("Country Not Found.", ErrorCode.CountryNotFound);

            var state = stateResponse.Data.Adapt<State>();  

            state.Name = request.Name;
            state.CountryId = request.CountryId;

            await _repository.UpdateIncludeAsync(state, "System", cancellationToken, nameof(State.Name), nameof(State.CountryId));

            var stateDto = state.Adapt<StateDto>();

            return RequestResult<StateDto>.Success(stateDto);
        }
    }



}
