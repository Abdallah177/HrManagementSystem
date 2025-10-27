using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.LocationManagement.CityManagement.AddCity.Dtos;
using HrManagementSystem.Features.LocationManagement.Common.City.Queries;
using Mapster;
using MediatR;

namespace HrManagementSystem.Features.LocationManagement.CityManagement.AddCity.Commands
{
    public record AddCityCommand(string Name, string StateId, string UserId) : IRequest<RequestResult<AddCityDto>>;

    public class AddCityCommandHandler : RequestHandlerBase<AddCityCommand, RequestResult<AddCityDto>, City>
    {
        public AddCityCommandHandler(RequestHandlerBaseParameters<City> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<AddCityDto>> Handle(AddCityCommand request, CancellationToken cancellationToken)
        {
            var isCityExistInTheState = await _mediator.Send(new IsCityExistInTheState(request.Name, request.StateId));

            if (isCityExistInTheState)
                return RequestResult<AddCityDto>.Failure("This City Already Exists In This State .", ErrorCode.CityAlreadyExistsInThisState);

            var City = request.Adapt<City>();

            await _repository.AddAsync(City, request.UserId, cancellationToken);

            var cityDto = City.Adapt<AddCityDto>();

            return RequestResult<AddCityDto>.Success(cityDto);
        }
    }


}
