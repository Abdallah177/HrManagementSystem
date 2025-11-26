
using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace HrManagementSystem.Common.Helper.HolidayService
{
    public class HolidayClient : IHolidayClient
    {
        private readonly HttpClient _httpClient;
        private readonly HolidayApiSettings _settings;

        public HolidayClient(HttpClient httpClient, IOptions<HolidayApiSettings> options)
        {
            _httpClient = httpClient;
            _settings = options.Value;
        }
        public async Task<List<HolidayDto>> GetHolidaysAsync(string country, int year)
        {
            var url = $"{_settings.BaseUrl}?api_key={_settings.ApiKey}&country={country}&year={year}";

            var response = await _httpClient.GetFromJsonAsync<CalendarificResponse>(url);

            return response?.Response?.Holidays ?? new List<HolidayDto>();

        }
    }
}
