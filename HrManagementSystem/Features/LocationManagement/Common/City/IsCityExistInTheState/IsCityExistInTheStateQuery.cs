using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Location;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.LocationManagement.Common.City.IsCityExistInTheState
{
    public record IsCityExistInTheStateQuery(string CityName, string StateId) : IRequest<bool>;

    public class IsCityExistInTheStateQueryHandler : RequestHandlerBase<IsCityExistInTheStateQuery, bool, HrManagementSystem.Common.Entities.Location.City>
    {
        public IsCityExistInTheStateQueryHandler(RequestHandlerBaseParameters<HrManagementSystem.Common.Entities.Location.City> parameters) : base(parameters)
        {
        }

        public override async Task<bool> Handle(IsCityExistInTheStateQuery request, CancellationToken cancellationToken)
        {
            var IsCityExists = await _repository.IsExistsAsync(C => C.Name == request.CityName && C.StateId == request.StateId);

            if (IsCityExists)
                return true;

            return false;
        }
    }
}
