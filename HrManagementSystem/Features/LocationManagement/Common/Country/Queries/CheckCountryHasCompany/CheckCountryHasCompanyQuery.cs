using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Views;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.LocationManagement.Common.Country.Queries.CheckCountryHasCompany
{
    public record CheckCountryHasCompanyQuery(string CountryId) : IRequest<RequestResult<bool>>;

    public class CheckCountryHasCompanyQueryHandler : RequestHandlerBase<CheckCountryHasCompanyQuery, RequestResult<bool>, Company>
    {
        public CheckCountryHasCompanyQueryHandler(RequestHandlerBaseParameters<Company> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(CheckCountryHasCompanyQuery request, CancellationToken cancellationToken)
        {
            var hasCompanies = await _repository.IsExistsAsync(c => c.CountryId == request.CountryId && !c.IsDeleted, cancellationToken);

            return RequestResult<bool>.Success(hasCompanies);
        }
    }
    
}
