using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.LocationManagement.CountryManagement.DeleteCountry.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.LocationManagement.CountryManagement.DeleteCountry.Queries
{
    public record GetStateIdsByCountryQuery(string countryId): IRequest<RequestResult<List<string>>>;

    public class GetStateIdsByCountryQueryHandler : RequestHandlerBase<GetStateIdsByCountryQuery, RequestResult<List<string>>, State>
    {
        public GetStateIdsByCountryQueryHandler(RequestHandlerBaseParameters<State> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<List<string>>> Handle(GetStateIdsByCountryQuery request, CancellationToken cancellationToken)
        {
            var stateIds = await _repository
                .Get( s => s.CountryId == request.countryId)
                .Select( s => s.Id)
                .ToListAsync(cancellationToken);

            return RequestResult<List<string>>.Success(stateIds);
        }
    }


}
