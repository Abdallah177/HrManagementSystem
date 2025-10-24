using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Common.Repositories;
using HrManagementSystem.Common.Views;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.LocationManagement.Common.State.Queries.CheckStateExists
{
    public record CheckStateExistsQuery(string Name, string CountryId) : IRequest<RequestResult<bool>>;

    public class CheckStateExistsQueryHandler : RequestHandlerBase<CheckStateExistsQuery, RequestResult<bool>, HrManagementSystem.Common.Entities.Location.State>
    {


        public CheckStateExistsQueryHandler(RequestHandlerBaseParameters<HrManagementSystem.Common.Entities.Location.State> parameters) : base(parameters)
        {
        }
        public async override Task<RequestResult<bool>> Handle(CheckStateExistsQuery request, CancellationToken cancellationToken)
        {
            var stateExists = await _repository.IsExistsAsync(s => s.Name == request.Name && s.CountryId == request.CountryId);

            return RequestResult<bool>.Success(stateExists);
        }
    }
}
