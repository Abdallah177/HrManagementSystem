using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.LocationManagement.CountryManagement.DeleteCountry.Commands;
using MediatR;

namespace HrManagementSystem.Features.LocationManagement.Common.City.DeleteCityByState.Command
{
    public record DeleteCityByStateCommand(string stateId , string currentUserId) : IRequest<RequestResult<bool>>;

    public class DeleteCityByStateCommandHandler : RequestHandlerBase<DeleteCityByStateCommand, RequestResult<bool>, HrManagementSystem.Common.Entities.Location.City>
    {
        public DeleteCityByStateCommandHandler(RequestHandlerBaseParameters<HrManagementSystem.Common.Entities.Location.City> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(DeleteCityByStateCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteFromAsync(c => c.StateId == request.stateId, request.currentUserId, cancellationToken);
            return RequestResult<bool>.Success(true, "Cities deleted successfully");
        }
    }
}
