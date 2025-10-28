using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.LocationManagement.CityManagement.UpdateCity.Query.GetCityById.Dtos;
using Mapster;
using MediatR;

namespace HrManagementSystem.Features.LocationManagement.CityManagement.UpdateCity.Query.GetCityById
{
    public record GetCityByIdQuery(string cityId) : IRequest<RequestResult<GetCityByIdDto>>;

    public class GetCityByIdQueryHandler : RequestHandlerBase<GetCityByIdQuery, RequestResult<GetCityByIdDto>, City>
    {
        public GetCityByIdQueryHandler(RequestHandlerBaseParameters<City> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<GetCityByIdDto>> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
        {
            var city = _repository.Get(c => c.Id == request.cityId)
                .ProjectToType<GetCityByIdDto>()
                .FirstOrDefault();

            if (city == null)
                return RequestResult<GetCityByIdDto>.Failure("City not found", ErrorCode.CityNotExist);
            return RequestResult<GetCityByIdDto>.Success(city);

        }
    }
}
