namespace HrManagementSystem.Common.Helper.HolidayService
{
    public class CalendarificResponse
    {
        public CalendarificMeta Meta { get; set; } = new CalendarificMeta();
        public CalendarificData Response { get; set; } = new CalendarificData();
    }
    public class CalendarificMeta
    {
        public int Code { get; set; }
    }

    public class CalendarificData
    {
        public List<HolidayDto> Holidays { get; set; } = new List<HolidayDto>();
    }
}
