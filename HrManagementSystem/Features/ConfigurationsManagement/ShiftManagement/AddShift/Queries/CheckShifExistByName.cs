using HrManagementSystem.Common.Entities.Features;
using HrManagementSystem.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.ConfigurationsManagement.ShiftManagement.AddShift.Queries
{
    public record CheckShiftExistByName(string Name) : IRequest<bool>;

    public class CheckShiftExistByNameHandler: RequestHandlerBase<CheckShiftExistByName, bool, Shift>
    {
        public CheckShiftExistByNameHandler(RequestHandlerBaseParameters<Shift> parameters)
            : base(parameters)
        {
        }

        public override async Task<bool> Handle(CheckShiftExistByName request, CancellationToken cancellationToken)
        {
            var exists = await _repository
                .Get(s => s.Name == request.Name)
                .AnyAsync(cancellationToken);

            return exists;
        }
    }

}
