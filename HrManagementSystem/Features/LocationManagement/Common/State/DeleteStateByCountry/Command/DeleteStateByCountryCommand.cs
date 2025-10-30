using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.LocationManagement.CountryManagement.DeleteCountry.Commands;
using MediatR;

namespace HrManagementSystem.Features.LocationManagement.Common.State.DeleteStateByCountry.Command
{
    public record DeleteStateByCountryCommand(string countryId , string currentUserId) : IRequest<RequestResult<bool>>;

    public class DeleteStateByCountryCommandHandler : RequestHandlerBase<DeleteStateByCountryCommand, RequestResult<bool>, HrManagementSystem.Common.Entities.Location.State>
    {
        public DeleteStateByCountryCommandHandler(RequestHandlerBaseParameters<HrManagementSystem.Common.Entities.Location.State> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(DeleteStateByCountryCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteFromAsync( s => s.CountryId == request.countryId, request.currentUserId, cancellationToken);
            return RequestResult<bool>.Success(true, "States deleted successfully");
        }
    }

}
