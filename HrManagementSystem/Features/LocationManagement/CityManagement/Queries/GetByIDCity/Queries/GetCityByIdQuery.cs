using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.LocationManagement.CityManagement.Queries.GetByIDCity.DTOs;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.LocationManagement.CityManagement.Queries.GetByIDCity.Queries
{


    public record GetCityByIdQuery(string Id) : IRequest<RequestResult<CityDTOs?>>;

    public class GetCityByIdQueryHandler : RequestHandlerBase<GetCityByIdQuery, RequestResult<CityDTOs?>, City>
    {
        public GetCityByIdQueryHandler(RequestHandlerBaseParameters<City> parameters) : base(parameters)
        { }

        public override async Task<RequestResult<CityDTOs?>> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
        {
            var city = await _repository.GetByIDAsync(request.Id, cancellationToken);

            if (city == null)
                return RequestResult<CityDTOs?>.Failure("The requested City was not found.", ErrorCode.CountryNotFound);

            var countryDto = city.Adapt<CityDTOs>(); 


            return RequestResult<CityDTOs?>.Success(countryDto);
        }
    }
}
