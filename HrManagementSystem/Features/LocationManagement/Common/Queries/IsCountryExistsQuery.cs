using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Location;
using MediatR;

namespace HrManagementSystem.Features.LocationManagement.Common.Queries
{
    public record IsCountryExistsQuery(string CountryId) : IRequest<bool>;

    public class IsCountryExistsQueryHandler : RequestHandlerBase<IsCountryExistsQuery, bool, Country>
    {
        public IsCountryExistsQueryHandler(RequestHandlerBaseParameters<Country> parameters) : base(parameters)
        {
        }

        public override async Task<bool> Handle(IsCountryExistsQuery request, CancellationToken cancellationToken)
        {
            var country = await _repository.GetByIDAsync(request.CountryId);

            if (country == null)
                return false;

            return true;
        }
    }


}
