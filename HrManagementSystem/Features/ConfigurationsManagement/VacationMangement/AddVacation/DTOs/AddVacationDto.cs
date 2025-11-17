using HrManagementSystem.Common.Enums.FeatureEnums;
using System.ComponentModel.DataAnnotations;

namespace HrManagementSystem.Features.ConfigurationsManagement.VacationMangement.AddVacation.DTOs
{
    public class AddVacationDto
    {
        public string Name { get; set; } = null!;

    
        public VacationType Type { get; set; }

        public int DurationInDays { get; set; }

       
        public string? Description { get; set; }
    }
}
