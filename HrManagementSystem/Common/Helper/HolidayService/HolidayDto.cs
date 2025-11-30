namespace HrManagementSystem.Common.Helper.HolidayService
{
    public class HolidayDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public List<string> Type { get; set; } = new();
        public HolidayDate Date { get; set; } = new HolidayDate();
    }

    public class HolidayDate
    {
        public string Iso { get; set; } = null!;
    }

}
