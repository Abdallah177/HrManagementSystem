using HrManagementSystem.Common.Enums.FeatureEnums;
using System.ComponentModel.DataAnnotations;

namespace HrManagementSystem.Features.ConfigurationsManagement.ProbationMangement.GetAllProbation.DTOs
{
    public class GetAllProbationDto
    {
        public string Id { get; set; }
        public int DurationInDays { get; set; }

        
        public string? EvaluationCriteria { get; set; }

        
        public string Status { get; set; } 
    }
}
