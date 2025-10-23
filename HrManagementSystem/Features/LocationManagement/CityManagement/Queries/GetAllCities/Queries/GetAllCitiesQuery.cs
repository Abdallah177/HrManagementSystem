using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Repositories;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.LocationManagement.CityManagement.Queries.GetAllCities.Queries.Dtos;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.LocationManagement.CityManagement.Queries.GetAllCities.Queries
{
    public record GetAllCitiesQuery : IRequest<RequestResult<List<CityResponseDto>>>;

    public class GetAllCitiesQueryHandler : RequestHandlerBase<GetAllCitiesQuery, RequestResult<List<CityResponseDto>>, City>
    {
        public GetAllCitiesQueryHandler(RequestHandlerBaseParameters<City> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<List<CityResponseDto>>> Handle(GetAllCitiesQuery request, CancellationToken cancellationToken)
        {

            var cities = await _repository.GetAll()
                .OrderBy(c => c.Name)
                .ProjectToType<CityResponseDto>()
                .ToListAsync(cancellationToken);
            if (cities == null)
                return RequestResult<List<CityResponseDto>>.Failure("No cities found", ErrorCode.NoCitiesfound);

            return RequestResult<List<CityResponseDto>>.Success(cities);
        }
    }
}
