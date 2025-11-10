using HrManagementSystem.Common.Enums.FeatureEnums;
using System.ComponentModel.DataAnnotations;

namespace HrManagementSystem.Features.ConfigurationsManagement.VacationMangement.UpdateVacation.DTOs
{
    public class UpdateVacationDto
    {
        public string Id { get; set; }

        public string Name { get; set; } = null!;
        public VacationType Type { get; set; } 
        public int DurationInDays { get; set; }
        public string? Description { get; set; }
    }
}
