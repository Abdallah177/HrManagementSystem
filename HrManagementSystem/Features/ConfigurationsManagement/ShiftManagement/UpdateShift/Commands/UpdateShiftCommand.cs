using HrManagementSystem.Common.Entities.Features;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common;
using HrManagementSystem.Common.Enums.FeatureEnums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.ConfigurationsManagement.ShiftManagement.AddShift.Queries;
using HrManagementSystem.Features.ConfigurationsManagement.ShiftManagement.UpdateShift.Dtos;
using MediatR;
using HrManagementSystem.Features.ConfigurationsManagement.ShiftManagement.GetShiftId.Queries;
using Mapster;

namespace HrManagementSystem.Features.ConfigurationsManagement.ShiftManagement.UpdateShift.Commands
{
    public record UpdateShiftCommand(string Id, string Name, ShiftType Type, TimeSpan StartTime, TimeSpan EndTime)
     : IRequest<RequestResult<UpdateShiftDto>>;


    public class UpdateShiftCommandHandler
    : RequestHandlerBase<UpdateShiftCommand, RequestResult<UpdateShiftDto>, Shift>
    {
        public UpdateShiftCommandHandler(RequestHandlerBaseParameters<Shift> parameters)
            : base(parameters)
        {
        }

        public override async Task<RequestResult<UpdateShiftDto>> Handle(UpdateShiftCommand request, CancellationToken cancellationToken)
        {

            var shiftResult = await _mediator.Send(new GetShiftByIdQuery(request.Id));

            if (!shiftResult.IsSuccess)
                return RequestResult<UpdateShiftDto>.Failure(shiftResult.Message, shiftResult.ErrorCode);

            var shiftEntity = shiftResult.Data.Adapt<Shift>();

            if (shiftEntity.Name != request.Name)
            {
                var isExist = await _mediator.Send(new CheckShiftExistByName(request.Name));

                if (isExist)
                    return RequestResult<UpdateShiftDto>.Failure(
                        "A shift with this name already exists.",
                        ErrorCode.DuplicateRecord
                    );
            }

            shiftEntity.Name = request.Name;
            shiftEntity.Type = request.Type;
            shiftEntity.StartTime = request.StartTime;
            shiftEntity.EndTime = request.EndTime;

            await _repository.UpdateIncludeAsync(
                shiftEntity,
                "System",
                cancellationToken,
                nameof(Shift.Name),
                nameof(Shift.Type),
                nameof(Shift.StartTime),
                nameof(Shift.EndTime)
            );

            var updateShiftDto = shiftEntity.Adapt<UpdateShiftDto>();

            return RequestResult<UpdateShiftDto>.Success(updateShiftDto);
        }
    }


}
