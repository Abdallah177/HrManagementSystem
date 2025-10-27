using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.Common.CheckExists;
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
            var IsCityExist = _mediator.Send(new CheckExistsQuery<City>(request.cityId));
            if (!IsCityExist.Result)
                return RequestResult<bool>.Failure("City not found" ,ErrorCode.CityNotExist);

            await _repository.Get(c => c.Id == request.cityId)
                  .ExecuteUpdateAsync(s => s
                  .SetProperty(c => c.Name, request.Name)
                  .SetProperty(c => c.StateId, request.StateId)
                  .SetProperty(c => c.UpdatedByUser, request.currentuserId)
                  .SetProperty(c => c.UpdatedAt, DateTime.UtcNow), cancellationToken);

            return RequestResult<bool>.Success(true, "City updated successfully");



        }
    }
}
