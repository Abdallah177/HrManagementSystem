using HrManagementSystem.Common.Entities.Features;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common;
using HrManagementSystem.Common.Enums.FeatureEnums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.ConfigurationsManagement.ShiftManagement.AddShift.Dtos;
using HrManagementSystem.Features.ConfigurationsManagement.ShiftManagement.AddShift.Queries;
using Mapster;
using MediatR;

namespace HrManagementSystem.Features.ConfigurationsManagement.ShiftManagement.AddShift.Commands
{
    public record AddShiftCommand(string Name, ShiftType Type, TimeSpan StartTime, TimeSpan EndTime): IRequest<RequestResult<AddShiftDto>>;

    public class AddShiftCommandHandler
    : RequestHandlerBase<AddShiftCommand, RequestResult<AddShiftDto>, Shift>
    {
        public AddShiftCommandHandler(RequestHandlerBaseParameters<Shift> parameters)
            : base(parameters)
        {
        }

        public override async Task<RequestResult<AddShiftDto>> Handle(AddShiftCommand request, CancellationToken cancellationToken)
        {
            // Check existence
            var isExist = await _mediator.Send(new CheckShiftExistByName(request.Name), cancellationToken);

            if (isExist)
                return RequestResult<AddShiftDto>.Failure(
                    "A shift with this name already exists.",
                    ErrorCode.DuplicateRecord
                );

           
            var shiftEntity = request.Adapt<Shift>();

           
            await _repository.AddAsync(shiftEntity, cancellationToken);

           
            var addShiftDto = shiftEntity.Adapt<AddShiftDto>();

            return RequestResult<AddShiftDto>.Success(addShiftDto);
        }
    }


}
