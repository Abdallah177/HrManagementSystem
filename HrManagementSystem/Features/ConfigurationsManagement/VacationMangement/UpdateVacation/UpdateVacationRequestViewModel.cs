using HrManagementSystem.Common.Enums.FeatureEnums;

namespace HrManagementSystem.Features.ConfigurationsManagement.VacationMangement.UpdateVacation
{
    public class UpdateVacationRequestViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; } = null!;
        public VacationType Type { get; set; }
        public int DurationInDays { get; set; }
        public string? Description { get; set; }
    }
}
