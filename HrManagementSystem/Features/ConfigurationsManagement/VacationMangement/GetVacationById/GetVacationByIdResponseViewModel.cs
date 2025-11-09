namespace HrManagementSystem.Features.ConfigurationsManagement.VacationMangement.GetVacationById
{
    public class GetVacationByIdResponseViewModel
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;

        public string Type { get; set; }

        public int DurationInDays { get; set; }


        public string Description { get; set; }
    }
}
