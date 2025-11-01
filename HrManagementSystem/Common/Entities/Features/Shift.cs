using HrManagementSystem.Common.Entities.FeatureSope;
using HrManagementSystem.Common.Enums.FeatureEnums;
using System.ComponentModel.DataAnnotations;

namespace HrManagementSystem.Common.Entities.Features
{
    public class Shift : BaseModel
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public ShiftType Type { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        public bool IsFlexible => Type == ShiftType.Flexible;

        
        public ICollection<ShiftScope> ShiftScopes { get; set; }
    }

}
