using HrManagementSystem.Common.Enums.FeatureEnums;

namespace HrManagementSystem.Features.ConfigurationsManagement.ProbationMangement.GetAllProbation
{
    public class GetAllProbtionResponseViewModel
    {
        public int DurationInDays { get; set; }


        public string? EvaluationCriteria { get; set; }


        public ProbationStatus Status { get; set; } = ProbationStatus.Active;
    }
}
