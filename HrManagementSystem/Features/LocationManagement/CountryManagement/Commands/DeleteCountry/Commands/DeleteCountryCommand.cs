using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Repositories;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.Common.Country.Queries.CheckCountryHasStates;
using HrManagementSystem.Features.Common.Queries.Location.Country.CheckCountryExists;
using HrManagementSystem.Features.LocationManagement.Common.Country.Queries.CheckCountryHasCompany;
using MediatR;

namespace HrManagementSystem.Features.LocationManagement.CountryManagement.Commands.DeleteCountry.Commands
{
    public record DeleteCountryCommand(string CountryId, string currentUserId) : IRequest<RequestResult<bool>>;

    public class DeleteCountryCommandHandler : RequestHandlerBase<DeleteCountryCommand, RequestResult<bool>, Country>
    {
        public DeleteCountryCommandHandler(RequestHandlerBaseParameters<Country> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            var CountryExists = await _mediator.Send(new CheckCountryExistsQuery(request.CountryId));
            if (!CountryExists.Data)
                return RequestResult<bool>.Failure("Country not found", ErrorCode.CountryNotFound);

            var hasStates = await _mediator.Send(new CheckCountryHasStatesQuery(request.CountryId));
            if (hasStates.Data)
                return RequestResult<bool>.Failure("Country related with states", ErrorCode.CountryHasStates);

            var hasCompany = await _mediator.Send(new CheckCountryHasCompanyQuery(request.CountryId));
            if (hasCompany.Data)
                return RequestResult<bool>.Failure("There is companies related with this country", ErrorCode.CountryHasRelatedCompanies);

            await _repository.DeleteAsync(request.CountryId, request.currentUserId, cancellationToken);

            return RequestResult<bool>.Success(true, "Country deleted successfully");
        }
    }
}
