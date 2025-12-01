using HrManagementSystem.Common.Enums.FeatureEnums;

namespace HrManagementSystem.Features.ConfigurationsManagement.ShiftManagement.GetAllShifts
{
    public record GetAllShiftsResponseViewModel(string Id, string Name, ShiftType Type, TimeSpan StartTime, TimeSpan EndTime);

}
