using HrManagementSystem.Common.Enums.FeatureEnums;

namespace HrManagementSystem.Features.ConfigurationsManagement.ShiftManagement.UpdateShift.Dtos
{
    public record UpdateShiftDto(string Id, string Name, ShiftType Type, TimeSpan StartTime, TimeSpan EndTime);

}
