using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.LocationManagement.StateManagement.DeleteState.Queries
{

    public record CheckStateHasCitiesQuery(string StateId) : IRequest<RequestResult<bool>>;

    public class CheckStateHasCitiesQueryHandler
        : RequestHandlerBase<CheckStateHasCitiesQuery, RequestResult<bool>, HrManagementSystem.Common.Entities.Location.City>
    {
        public CheckStateHasCitiesQueryHandler(RequestHandlerBaseParameters<HrManagementSystem.Common.Entities.Location.City> parameters)
            : base(parameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(CheckStateHasCitiesQuery request, CancellationToken cancellationToken)
        {

            var hasCities = await _repository.GetAll()
                .AsNoTracking()
                .AnyAsync(c => c.StateId == request.StateId && !c.IsDeleted, cancellationToken);

            return RequestResult<bool>.Success(hasCities);
        }
    }
}
