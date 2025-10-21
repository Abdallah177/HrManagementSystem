using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using MediatR;

namespace HrManagementSystem.Features.LocationManagement.Common.Queries
{
    public record IsStateExistQuery(string StateId) : IRequest<bool>;

    public class IsStateExistQueryHandler : RequestHandlerBase<IsStateExistQuery, bool, State>
    {
        public IsStateExistQueryHandler(RequestHandlerBaseParameters<State> parameters) : base(parameters)
        {
        }

        public override async Task<bool> Handle(IsStateExistQuery request, CancellationToken cancellationToken)
        {
            var state = await _repository.GetByIDAsync(request.StateId);

            if (state == null)
                return false;

            return true;
        }
    }

}
