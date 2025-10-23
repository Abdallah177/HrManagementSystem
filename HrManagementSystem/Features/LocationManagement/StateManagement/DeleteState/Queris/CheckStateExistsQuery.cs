using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.LocationManagement.StateManagement.DeleteState.Queries
{

    public record CheckStateExistsQuery(string StateId) : IRequest<RequestResult<bool>>;

    public class CheckStateExistsQueryHandler
        : RequestHandlerBase<CheckStateExistsQuery, RequestResult<bool>, HrManagementSystem.Common.Entities.Location.State>
    {
        public CheckStateExistsQueryHandler(RequestHandlerBaseParameters<HrManagementSystem.Common.Entities.Location.State> parameters)
            : base(parameters)
        { }

        public override async Task<RequestResult<bool>> Handle(CheckStateExistsQuery request, CancellationToken cancellationToken)
        {

            var exists = await _repository.GetAll()
                .AsNoTracking()
                .AnyAsync(s => s.Id == request.StateId && !s.IsDeleted, cancellationToken);

            return RequestResult<bool>.Success(exists);
        }
    }
}
