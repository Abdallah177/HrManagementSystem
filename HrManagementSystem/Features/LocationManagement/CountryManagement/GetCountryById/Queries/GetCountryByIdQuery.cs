
using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.LocationManagement.CountryManagement.GetCountryById.Dtos;
using Mapster;
using MediatR;

namespace HrManagementSystem.Features.LocationManagement.CountryManagement.GetByIdCountry.Queries
{
    public record GetCountryByIdQuery(string Id ) : IRequest<RequestResult<CountryDto?>>;

    public class GetCountryByIdQueryHandler : RequestHandlerBase<GetCountryByIdQuery, RequestResult<CountryDto?>, Country>
    {
        public GetCountryByIdQueryHandler(RequestHandlerBaseParameters<Country> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<CountryDto?>> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
        {
            var country = await _repository.GetByIDAsync(request.Id, cancellationToken);

            if (country == null)
                return RequestResult<CountryDto?>.Failure("The requested country was not found.", ErrorCode.CountryNotFound);

            var countryDto = country.Adapt<CountryDto>();

            return RequestResult<CountryDto?>.Success(countryDto); 
        }
    }



}
