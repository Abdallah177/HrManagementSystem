using HrManagementSystem.Common.Enums.FeatureEnums;

namespace HrManagementSystem.Features.DisabilityManagement.UpdateDisability
{
    public class UpdateDisabilityRequestViewModel
    {
        public string Id {  get; set; }
        public DisabilityType Type { get; set; }
        public string? Description { get; set; }
        public bool RequiresSpecialSupport { get; set; }
    }
}
