namespace HrManagementSystem.Common.Helper.HolidayService
{
    public class HolidayDto
    {
        public string Name { get; set; } = null!;
        public string Date { get; set; } = null!;

        public string Type { get; set; } = "National";

        public string? Description { get; set; }
    }
}
