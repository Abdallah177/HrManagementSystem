namespace HrManagementSystem.Features.ConfigurationsManagement.ProbationMangement.GetProbationById.DTOs
{
    public class GetProbationByIDDto
    {
        public string Id { get; set; }
        public int DurationInDays { get; set; }


        public string? EvaluationCriteria { get; set; }


        public string Status { get; set; }
    }
}
