using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using MediatR;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Features.Common.CheckExists;
using HrManagementSystem.Features.LocationManagement.Common.Country.Queries.CheckCountryHasCompany;
using HrManagementSystem.Features.LocationManagement.StateManagement.Common.Commands;
using HrManagementSystem.Features.LocationManagement.CountryManagement.DeleteCountry.Queries;

namespace HrManagementSystem.Features.LocationManagement.CountryManagement.DeleteCountry.Commands
{
    public record DeleteCountryOrchestrator(string countryId, string currentuserId) : IRequest<RequestResult<bool>>;

    public class DeleteCountryOrchestratorHandler : RequestHandlerBase<DeleteCountryOrchestrator, RequestResult<bool>, Country>
    {
        public DeleteCountryOrchestratorHandler(RequestHandlerBaseParameters<Country> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(DeleteCountryOrchestrator request, CancellationToken cancellationToken)
        {
            var countryExists = await _mediator.Send(new CheckExistsQuery<Country>(request.countryId));
            if (!countryExists)
                return RequestResult<bool>.Failure("Country not found", ErrorCode.CountryNotFound);

            var hasCompany = await _mediator.Send(new CheckCountryHasCompanyQuery(request.countryId));
            if (hasCompany.Data)
                return RequestResult<bool>.Failure("There is companies related with this country", ErrorCode.CountryHasRelatedCompanies);

            var stateIds = await _mediator.Send(new GetStateIdsByCountryQuery(request.countryId));
            if (stateIds.Data.Any())
            {
                foreach (var stateId in stateIds.Data)
                {
                    //await _mediator.Send(new DeleteCityByStateCommand(stateId, request.currentuserId));
                }
            }

            //await _mediator.Send(new DeleteStateByCountryCommand(request.countryId,request.currentuserId));

            await _mediator.Send(new DeleteCountryCommand(request.countryId,request.currentuserId));

            return RequestResult<bool>.Success(true, "Country and all related states and cities deleted successfully");

        }
    }
}

