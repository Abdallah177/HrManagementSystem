using HrManagementSystem.Common.Entities.Features;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using MediatR;
using Mapster;
using HrManagementSystem.Features.ConfigurationsManagement.Common.Shift.Dtos;

namespace HrManagementSystem.Features.ConfigurationsManagement.ShiftManagement.GetShiftId.Queries
{
    public record GetShiftByIdQuery(string Id) : IRequest<RequestResult<ShiftDto>>;

    public class GetShiftByIdQueryHandler
    : RequestHandlerBase<GetShiftByIdQuery, RequestResult<ShiftDto>, Shift>
    {
        public GetShiftByIdQueryHandler(RequestHandlerBaseParameters<Shift> parameters)
            : base(parameters)
        {
        }

        public override async Task<RequestResult<ShiftDto>> Handle(GetShiftByIdQuery request, CancellationToken cancellationToken)
        {
            var shift = await _repository.GetByIDAsync(request.Id);

            if (shift == null)
                return RequestResult<ShiftDto>.Failure(
                    "Shift Not Found.",
                    ErrorCode.ShiftNotExist
                );

            var shiftDto = shift.Adapt<ShiftDto>();

            return RequestResult<ShiftDto>.Success(shiftDto);
        }
    }


}
