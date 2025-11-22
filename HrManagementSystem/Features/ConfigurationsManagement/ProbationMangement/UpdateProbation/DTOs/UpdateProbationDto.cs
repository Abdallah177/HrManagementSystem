using HrManagementSystem.Common.Enums.FeatureEnums;

namespace HrManagementSystem.Features.ConfigurationsManagement.ProbationMangement.UpdateProbation.DTOs
{
    public class UpdateProbationDto
    {
        public string Id { get; set; }
        public int DurationInDays { get; set; }


        public string? EvaluationCriteria { get; set; }


        public ProbationStatus Status { get; set; } 
    }
}
