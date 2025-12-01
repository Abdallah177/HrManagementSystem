using HrManagementSystem.Common.Enums.FeatureEnums;

namespace HrManagementSystem.Features.ConfigurationsManagement.ShiftManagement.GetShiftId
{
    public record GetShiftByIdResponseViewModel(string Id, string Name, ShiftType Type, TimeSpan StartTime, TimeSpan EndTime);

}
