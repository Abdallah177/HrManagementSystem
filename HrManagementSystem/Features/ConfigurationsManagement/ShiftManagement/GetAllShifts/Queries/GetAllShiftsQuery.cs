using HrManagementSystem.Common.Entities.Features;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.ConfigurationsManagement.Common.Shift.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Mapster;

namespace HrManagementSystem.Features.ConfigurationsManagement.ShiftManagement.GetAllShifts.Queries
{
    public record GetAllShiftsQuery : IRequest<RequestResult<List<ShiftDto>>>;

    public class GetAllShiftsQueryHandler
    : RequestHandlerBase<GetAllShiftsQuery, RequestResult<List<ShiftDto>>, Shift>
    {
        public GetAllShiftsQueryHandler(RequestHandlerBaseParameters<Shift> parameters)
            : base(parameters)
        {
        }

        public override async Task<RequestResult<List<ShiftDto>>> Handle(GetAllShiftsQuery request, CancellationToken cancellationToken)
        {
            var shifts = await _repository.GetAll().ToListAsync(cancellationToken);

            if (!shifts.Any())
                return RequestResult<List<ShiftDto>>
                    .Failure("No Shift Found.", ErrorCode.NonShiftFound);

            var shiftDto = shifts.Adapt<List<ShiftDto>>();

            return RequestResult<List<ShiftDto>>.Success(shiftDto);
        }
    }

}
