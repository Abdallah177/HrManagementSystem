using HrManagementSystem.Common.Enums.FeatureEnums;

namespace HrManagementSystem.Features.ConfigurationsManagement.ShiftManagement.AddShift.Dtos
{
    public record AddShiftDto(string Id,string Name, ShiftType Type, TimeSpan StartTime, TimeSpan EndTime);


}
