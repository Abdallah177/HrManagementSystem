using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using MediatR;
using HrManagementSystem.Common.Entities.Location;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.OnBoardingManagement.Queries
{
    public record GetDefaultCitiesByCountryIdsQuery(List<string> countries):IRequest<RequestResult<Dictionary<string,string>>>;
    public class GetDefaultCitiesByCountryIdsQueryHandler : RequestHandlerBase<GetDefaultCitiesByCountryIdsQuery, RequestResult<Dictionary<string, string>>, State>
    {
        public GetDefaultCitiesByCountryIdsQueryHandler(RequestHandlerBaseParameters<State> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<Dictionary<string, string>>> Handle(GetDefaultCitiesByCountryIdsQuery request, CancellationToken cancellationToken)
        {
            var countryDefaultCities = await _repository
                    .Get(s => request.countries.Contains(s.CountryId))
                    .GroupBy(s => s.CountryId)
                    .Select(g => new 
                    {
                        CountryId = g.Key,
                        FirstState = g.OrderBy(s => s.Name).FirstOrDefault()
                    })
                    .Select(x => new 
                    {
                        x.CountryId,
                        FirstCityId = x.FirstState.Cities  
                        .OrderBy(c => c.Name)
                        .Select(c => c.Id)
                        .FirstOrDefault()
                    })
                    .ToDictionaryAsync(x => x.CountryId, x => x.FirstCityId);

            return RequestResult<Dictionary<string, string>>.Success(countryDefaultCities);
        }
    }

}
