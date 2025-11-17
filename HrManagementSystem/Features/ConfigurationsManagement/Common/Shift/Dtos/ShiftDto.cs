using HrManagementSystem.Common.Enums.FeatureEnums;

namespace HrManagementSystem.Features.ConfigurationsManagement.Common.Shift.Dtos
{
    public record ShiftDto(string Id, string Name, ShiftType Type, TimeSpan StartTime, TimeSpan EndTime);


}
