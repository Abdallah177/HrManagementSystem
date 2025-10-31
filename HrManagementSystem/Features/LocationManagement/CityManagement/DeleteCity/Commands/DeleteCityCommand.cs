using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.LocationManagement.CityManagement.Queries.GetByIDCity.Queries;
using MediatR;

namespace HrManagementSystem.Features.LocationManagement.CityManagement.DeleteCity.Commands
{
    public record DeleteCityCommand(string Id, string UserId) : IRequest<RequestResult<bool>>;

    public class DeleteCityCommandHandler : RequestHandlerBase<DeleteCityCommand, RequestResult<bool>, City>
    {
        public DeleteCityCommandHandler(RequestHandlerBaseParameters<City> parameters) : base(parameters) { }
        public override async Task<RequestResult<bool>> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            var city = await _mediator.Send(new GetCityByIdQuery(request.Id));
            if (!city.IsSuccess)
                return RequestResult<bool>.Failure("City Not Found", ErrorCode.NoCitiesfound);


            await _repository.DeleteAsync(request.Id, request.UserId,cancellationToken);

            return RequestResult<bool>.Success(true, "City deleted successfully");
        }
    }

}
