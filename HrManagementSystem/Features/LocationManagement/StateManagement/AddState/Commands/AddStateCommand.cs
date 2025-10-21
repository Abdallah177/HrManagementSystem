using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Repositories;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.Common.Country.Queries.CheckCountryExists;
using HrManagementSystem.Features.Common.State.Queries.CheckStateExists;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.LocationManagement.StateManagement.AddState.Commands
{
    public record AddStateCommand(string Name, string CountryId , string currentUserId) : IRequest<RequestResult<bool>>;

    public class AddStateCommandHandler : RequestHandlerBase<AddStateCommand, RequestResult<bool>,State>
    {
        public AddStateCommandHandler(RequestHandlerBaseParameters<State> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(AddStateCommand request , CancellationToken cancellationToken)
        {
            var countryExistsResult = await _mediator.Send(new CheckCountryExistsQuery(request.CountryId));

            if (!countryExistsResult.Data)
                return RequestResult<bool>.Failure("Country not found", ErrorCode.CountryNotFound);

            var stateExistsResult = await _mediator.Send(new CheckStateExistsQuery(request.Name , request.CountryId));
            if (stateExistsResult.Data)
                return RequestResult<bool>.Failure("state is exist in the same country", ErrorCode.StateIsExist);

            var state = request.Adapt<State>();

            await _repository.AddAsync(state,request.currentUserId,cancellationToken);

            return RequestResult<bool>.Success(true,"State created successfully");


        }
    }
}
