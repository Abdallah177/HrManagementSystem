using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using MediatR;

namespace HrManagementSystem.Features.LocationManagement.CountryManagement.GetById.Queries
{
    public record GetCountryByIdQuery(string Id ) : IRequest<RequestResult<Country?>>;

    public class GetCountryByIdQueryHandler : RequestHandlerBase<GetCountryByIdQuery, RequestResult<Country?>, Country>
    {
        public GetCountryByIdQueryHandler(RequestHandlerBaseParameters<Country> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<Country?>> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
        {
            var country = await _repository.GetByIDAsync(request.Id, cancellationToken);

            if (country == null)
                return RequestResult<Country?>.Failure("The requested country was not found.", ErrorCode.CountryNotFound);

            return RequestResult<Country?>.Success(country); 
        }
    }



}
