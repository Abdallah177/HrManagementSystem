using HrManagementSystem.Common.Enums.FeatureEnums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrManagementSystem.Common.Entities.Features
{
    public class PublicHoliday : BaseModel
    {
        [Required, MaxLength(200)]
        public string Name { get; set; } = null!;

        
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [Required]
        public PublicHolidayType Type { get; set; } = PublicHolidayType.National;

        [Required, MaxLength(100)]
        public string Country { get; set; } = "EG";

        [MaxLength(100)]
        public string? ExternalSource { get; set; }  

        [MaxLength(200)]
        public string? ExternalKey { get; set; }    

        [MaxLength(500)]
        public string? Description { get; set; }
    }
}
