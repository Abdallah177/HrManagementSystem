using HrManagementSystem.Common.Enums.FeatureEnums;
using System.ComponentModel.DataAnnotations;

namespace HrManagementSystem.Features.ConfigurationsManagement.ProbationMangement.AddProbation.DTOs
{
    public class AddProbationDto
    {
        public int DurationInDays { get; set; }

       
        public string? EvaluationCriteria { get; set; }

        
        public ProbationStatus Status { get; set; } = ProbationStatus.Active;
    }
}
