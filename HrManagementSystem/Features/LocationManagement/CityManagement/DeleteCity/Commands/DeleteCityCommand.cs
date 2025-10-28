using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using MediatR;

namespace HrManagementSystem.Features.LocationManagement.CityManagement.DeleteCity.Commands
{
    public record DeleteCityCommand(string Id, string UserId) : IRequest<RequestResult<bool>>;

    public class DeleteCityCommandHandler : RequestHandlerBase<DeleteCityCommand, RequestResult<bool>, State>
    {
        public DeleteCityCommandHandler(RequestHandlerBaseParameters<State> parameters) : base(parameters) { }
        public override async Task<RequestResult<bool>> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            // Will Be Refactoring After Making Get By Id
            var city = await _repository.GetByIDAsync(request.Id, cancellationToken);
            if (city == null)
                return RequestResult<bool>.Failure("City Not Found", ErrorCode.NoCitiesfound);


            city.IsDeleted = true;
            city.IsActive = false;
            city.UpdatedByUser = request.UserId;
            city.UpdatedAt = DateTime.UtcNow;

            _repository.Update(city, request.UserId);

            return RequestResult<bool>.Success(true, "City deleted successfully");
        }
    }

}
