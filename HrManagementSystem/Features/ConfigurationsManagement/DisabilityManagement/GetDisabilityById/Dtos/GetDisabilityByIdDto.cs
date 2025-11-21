using HrManagementSystem.Common.Enums.FeatureEnums;

namespace HrManagementSystem.Features.DisabilityManagement.GetDisabilityById.Dtos
{
    public class GetDisabilityByIdDto
    {
        public DisabilityType Type { get; set; }
        public string? Description { get; set; }
        public bool RequiresSpecialSupport { get; set; }

    }
}
