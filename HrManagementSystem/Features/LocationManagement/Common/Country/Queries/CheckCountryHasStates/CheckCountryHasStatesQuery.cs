using HrManagementSystem.Common;
using HrManagementSystem.Common.Repositories;
using HrManagementSystem.Common.Views;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.Common.Country.Queries.CheckCountryHasStates
{
    public record CheckCountryHasStatesQuery(string countryId) : IRequest<RequestResult<bool>>;

    public class CheckCountryHasStatesQueryHandler : RequestHandlerBase<CheckCountryHasStatesQuery, RequestResult<bool>, HrManagementSystem.Common.Entities.Location.State>
    {
        //handler
        public CheckCountryHasStatesQueryHandler(RequestHandlerBaseParameters<HrManagementSystem.Common.Entities.Location.State> parameters) : base(parameters)
        {
        }
        public async override Task<RequestResult<bool>> Handle(CheckCountryHasStatesQuery request, CancellationToken cancellationToken)
        {
            var hasStates = await _repository.IsExistsAsync(s => s.CountryId == request.countryId, cancellationToken);

            return RequestResult<bool>.Success(hasStates);
        }
    }


}

