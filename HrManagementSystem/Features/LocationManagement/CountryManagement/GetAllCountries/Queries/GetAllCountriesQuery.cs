using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Repositories;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Common.Entities.Location;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using HrManagementSystem.Common;
using HrManagementSystem.Features.LocationManagement.CountryManagement.Queries.GetAllCountries;
using System.Threading;

namespace HrManagementSystem.Features.LocationManagement.CountryManagement.Queries.GetAllCountries.Queries
{
    public record GetAllCountriesQuery() : IRequest<RequestResult<List<GetAllCountriesViewModel>>>;


    public class GetAllCountriesQueryHandler : RequestHandlerBase<GetAllCountriesQuery, RequestResult<List<GetAllCountriesViewModel>>, Country>
    {
        public GetAllCountriesQueryHandler(RequestHandlerBaseParameters<Country> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<List<GetAllCountriesViewModel>>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
        {
            var countries = await _repository.GetAll()
                                  .ToListAsync(cancellationToken);

            if (countries is null || !countries.Any())
                return RequestResult<List<GetAllCountriesViewModel>>.Failure("No countries found", ErrorCode.CountryNotFound);


            var viewModels = countries.Adapt<List<GetAllCountriesViewModel>>();
            return RequestResult<List<GetAllCountriesViewModel>>.Success(viewModels, "Countries retrieved successfully");
        }
    }

}
