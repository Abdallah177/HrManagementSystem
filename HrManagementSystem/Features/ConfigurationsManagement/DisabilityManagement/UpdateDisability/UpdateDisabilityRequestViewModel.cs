using HrManagementSystem.Common.Enums.FeatureEnums;

namespace HrManagementSystem.Features.DisabilityManagement.UpdateDisability
{
    public record UpdateDisabilityRequestViewModel(string Id , DisabilityType Type , string? Description, bool RequiresSpecialSupport);
}
