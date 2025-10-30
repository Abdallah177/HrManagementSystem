using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Repositories;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.Common.Country.Queries.CheckCountryHasStates;
using HrManagementSystem.Features.LocationManagement.Common.Country.Queries.CheckCountryHasCompany;
using MediatR;

namespace HrManagementSystem.Features.LocationManagement.CountryManagement.DeleteCountry.Commands
{
    public record DeleteCountryCommand(string countryId , string currentUserId) : IRequest<RequestResult<bool>>;

    public class DeleteCountryCommandHandler : RequestHandlerBase<DeleteCountryCommand, RequestResult<bool>,Country>
    {
        public DeleteCountryCommandHandler(RequestHandlerBaseParameters<Country> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            //var hasStates = await _mediator.Send(new CheckCountryHasStatesQuery(request.CountryId));
            //if (hasStates.Data)
            //    return RequestResult<bool>.Failure("Country related with states", ErrorCode.CountryHasStates);

            await _repository.DeleteFromAsync(c => c.Id == request.countryId ,request.currentUserId,cancellationToken);

            return RequestResult<bool>.Success(true, "Country deleted successfully");
        }
    }
}
