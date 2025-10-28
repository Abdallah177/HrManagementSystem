using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.Common.CheckExists;
using HrManagementSystem.Features.LocationManagement.CityManagement.UpdateCity.Query.CheckDublicateCityNameInState;
using HrManagementSystem.Features.LocationManagement.CityManagement.UpdateCity.Query.GetCityById;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.LocationManagement.CityManagement.UpdateCity.Commands
{
    public record UpdateCityCommand(string cityId,string Name , string StateId , string currentuserId) : IRequest<RequestResult<bool>>;

    public class UpdateCityCommandHandler : RequestHandlerBase<UpdateCityCommand, RequestResult<bool>, City>
    {
        public UpdateCityCommandHandler(RequestHandlerBaseParameters<City> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            var cityResult = await _mediator.Send(new GetCityByIdQuery(request.cityId));

            if (!cityResult.IsSuccess)
                return RequestResult<bool>.Failure(cityResult.Message, cityResult.ErrorCode);

            var stateExists = await _mediator.Send(new CheckExistsQuery<State>(request.StateId));
            if (!stateExists)
                return RequestResult<bool>.Failure("State not found", ErrorCode.StateNotFound);

            var duplicateCityResult = await _mediator.Send(new CheckDublicateCityNameInStateQuery(request.StateId, request.Name));
            if (duplicateCityResult.IsSuccess)
                return RequestResult<bool>.Failure(duplicateCityResult.Message, duplicateCityResult.ErrorCode);

            var city = cityResult.Data.Adapt<City>();
            request.Adapt(city);

            await _repository.UpdateIncludeAsync(
                city,
                request.currentuserId,
                cancellationToken,
                nameof(City.Name),
                nameof(City.StateId)
            );

            return RequestResult<bool>.Success(true, "City updated successfully");



        }
    }
}
