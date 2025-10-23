using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Location;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.LocationManagement.Common.City.Queries
{
    public record IsCityExistInTheState (string CityName ,string StateId) : IRequest<bool>;

    public class IsCityExistInTheStateHandler : RequestHandlerBase<IsCityExistInTheState, bool, HrManagementSystem.Common.Entities.Location.City>
    {
        public IsCityExistInTheStateHandler(RequestHandlerBaseParameters<HrManagementSystem.Common.Entities.Location.City> parameters) : base(parameters)
        {
        }

        public override async Task<bool> Handle(IsCityExistInTheState request, CancellationToken cancellationToken)
        {
            var IsCityExists = await  _repository.Get(C => C.Name == request.CityName && C.StateId == request.StateId).AnyAsync(cancellationToken);

            if (IsCityExists)
                return true;

            return false;
        }
    }
}
