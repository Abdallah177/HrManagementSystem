using HrManagementSystem.Common;
using HrManagementSystem.Common.Repositories;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Common.Entities.Location;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HrManagementSystem.Features.Common.Location.Country.CheckCountryExists
{
    public record CheckCountryExistsQuery(string CountryId) : IRequest<RequestResult<bool>>;

    public class CheckCountryExistsQueryHandler : RequestHandlerBase<CheckCountryExistsQuery, RequestResult<bool>, HrManagementSystem.Common.Entities.Location.Country>
    {

        public CheckCountryExistsQueryHandler(RequestHandlerBaseParameters<HrManagementSystem.Common.Entities.Location.Country> parameters) : base(parameters)
        {

        }

        public async override Task<RequestResult<bool>> Handle(CheckCountryExistsQuery request, CancellationToken cancellationToken)
        {
            var countryExists = await _repository.IsExistsAsync(c => c.Id == request.CountryId);

            return RequestResult<bool>.Success(countryExists);
        }
    }
}
