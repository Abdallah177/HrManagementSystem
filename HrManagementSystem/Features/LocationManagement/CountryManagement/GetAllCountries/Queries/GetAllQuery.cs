using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Repositories;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Common.Entities.Location;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using HrManagementSystem.Common;

namespace HrManagementSystem.Features.LocationManagement.CountryManagement.GetAllCountries.Queries
{
    public record GetAllCountriesQuery() : IRequest<EndpointResponse<List<GetAllCountriesViewModel>>>;


    public class GetAllCountriesHandler : RequestHandlerBase<GetAllCountriesQuery, EndpointResponse<List<GetAllCountriesViewModel>>, Country>
    {
        private readonly IGenericRepository<Country> _genericRepository;

        public GetAllCountriesHandler(IGenericRepository<Country> genericRepository, RequestHandlerBaseParameters<Country> parameters)
            : base(parameters)
        {
            _genericRepository = genericRepository;
        }

        public override async Task<EndpointResponse<List<GetAllCountriesViewModel>>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
        {
            var countries = await _genericRepository.GetAll()
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            if (countries is null || !countries.Any())
                return EndpointResponse<List<GetAllCountriesViewModel>>.Failure("No countries found", ErrorCode.CountryNotFound);

            var viewModels = countries.Adapt<List<GetAllCountriesViewModel>>();
            return EndpointResponse<List<GetAllCountriesViewModel>>.Success(viewModels, "Countries retrieved successfully");
        }
    }
}
