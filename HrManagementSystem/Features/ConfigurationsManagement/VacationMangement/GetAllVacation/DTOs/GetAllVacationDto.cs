using HrManagementSystem.Common.Enums.FeatureEnums;
using System.ComponentModel.DataAnnotations;

namespace HrManagementSystem.Features.ConfigurationsManagement.VacationMangement.GetAllVacation.DTOs
{
    public class GetAllVacationDto
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;

        public string Type { get; set; }

        public int DurationInDays { get; set; }

       
        public string Description { get; set; }
    }
}
