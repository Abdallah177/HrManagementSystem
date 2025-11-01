using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using MediatR;

namespace HrManagementSystem.Features.LocationManagement.CityManagement.UpdateCity.Query.CheckDublicateCityNameInState
{
    public record CheckDublicateCityNameInStateQuery(string stateId , string Name) : IRequest<RequestResult<bool>>;
    public class CheckDublicateCityNameInStateQueryHandler : RequestHandlerBase<CheckDublicateCityNameInStateQuery, RequestResult<bool>,City>
    {
        public CheckDublicateCityNameInStateQueryHandler(RequestHandlerBaseParameters<City> parameters) : base(parameters)
        {
        }
        public async override Task<RequestResult<bool>> Handle(CheckDublicateCityNameInStateQuery request, CancellationToken cancellationToken)
        {
            var isCityDeuplicated = await _repository.IsExistsAsync(c => c.StateId == request.stateId && c.Name.Trim().ToLower() == request.Name.Trim().ToLower());
            if (isCityDeuplicated)
                return RequestResult<bool>.Failure("City name already exists in the specified state" ,ErrorCode.DuplicateCityName);

            return RequestResult<bool>.Success(isCityDeuplicated);
        }
    }
}
