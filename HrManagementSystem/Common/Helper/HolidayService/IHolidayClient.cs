namespace HrManagementSystem.Common.Helper.HolidayService
{
    public interface IHolidayClient
    {
        Task<List<HolidayDto>> GetHolidaysAsync(string country, int year);
    }
}
