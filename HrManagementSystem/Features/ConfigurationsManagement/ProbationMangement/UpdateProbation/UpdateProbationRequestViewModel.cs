namespace HrManagementSystem.Features.ConfigurationsManagement.ProbationMangement.UpdateProbation
{
    public record UpdateProbationRequestViewModel(string Id, int DurationInDays, string? EvaluationCriteria);

}
