

using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.Common.Queries.Location.Country.CheckCountryExists;
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
            var state = await _repository.GetByIDAsync(request.StateId);

            if (state == null)
                return  RequestResult<StateDto>.Failure("State Not Found.", ErrorCode.StateNotFound);

            var IsCountryExist = await _mediator.Send(new CheckCountryExistsQuery(request.CountryId));

            if (!IsCountryExist.IsSuccess)
                return RequestResult<StateDto>.Failure("Country Not Found.", ErrorCode.CountryNotFound);

            state.Name = request.Name;
            state.CountryId = request.CountryId;

            _repository.Update(state);

            var stateDto = state.Adapt<StateDto>();

            return RequestResult<StateDto>.Success(stateDto);
        }
    }



}
